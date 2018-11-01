#!/bin/bash
### BEGIN INIT INFO
# Provides:        selenium-firefox
# Required-Start:  $network $remote_fs $syslog
# Required-Stop:   $network $remote_fs $syslog
# Default-Start:   2 3 4 5
# Default-Stop:
# Short-Description: Start selenium-firefox deamon
### END INIT INFO

#mkdir -p /var/log/selenium-firefox
#chmod a+w /var/log/selenium-firefox

INSTACE_LOCAL_IP="10.140.0.2"
SELENIUM_JAR_PATH="/home/selenium/selenium-server-standalone-3.10.0.jar"
SELENIUM_HUB_ROTE="http://35.195.16.18:4444/grid/register/"
SELENIUM_NODE_PORT="1442"
BROWSER_NAME="firefox"
LOG_PATH="/var/log/selenium-firefox/output.log"
LOG_ERROR_PATH="/var/log/selenium-chrome/error.log"
PID_PATH="/tmp/selenium-firefox.pid"

case "$1" in
    start)
        if test -f $PID_PATH
        then
            echo "Selenium is already running."
        else
            export DISPLAY=$INSTACE_LOCAL_IP:99.0
            java -jar $SELENIUM_JAR_PATH -role webdriver -hub $SELENIUM_HUB_ROTE -port $SELENIUM_NODE_PORT -browser browserName=$BROWSER_NAME > LOG_PATH 2> $LOG_ERROR_PATH & echo $! > $PID_PATH
            echo "Starting Selenium..."
            error=$?
            if test $error -gt 0
            then
                echo "${bon}Error $error! Couldn't start Selenium!${boff}"
            fi
        fi
    ;;
    stop)
        if test -f $PID_PATH
        then
            echo "Stopping Selenium..."
            PID=$(cat $PID_PATH)

            kill  $PID
            if kill $PID ;
                then
                    sleep 2
                    test -f $PID_PATH && rm -f $PID_PATH
                else
                    echo "Selenium could not be stopped..."
                fi
        else
            echo "Selenium is not running."
        fi
    ;;
    restart)
   if test -f $PID_PATH
        then
            kill $(cat $PID_PATH)
            test -f $PID_PATH && rm -f $PID_PATH
            sleep 1
            export DISPLAY=$INSTACE_LOCAL_IP:99.0
            java -jar $SELENIUM_JAR_PATH -role webdriver -hub $SELENIUM_HUB_ROTE -port $SELENIUM_NODE_PORT -browser browserName=$BROWSER_NAME > LOG_PATH 2> $LOG_ERROR_PATH & echo $! > $PID_PATH
            echo "Reload Selenium..."
        else
            echo "Selenium isn't running..."
        fi
        ;;
    *)      # no parameter specified
        echo "Usage: $SELF start|stop|restart"
        exit 1
    ;;
esac
