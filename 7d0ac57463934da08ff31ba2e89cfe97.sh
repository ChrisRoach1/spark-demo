function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}
ps 83719;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 83719 > /dev/null;
done;
for child in $(list_child_processes 83743);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/chrisroach/Documents/Projects/spark-demo/7d0ac57463934da08ff31ba2e89cfe97.sh;
