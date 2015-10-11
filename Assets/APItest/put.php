<?php
require("./db_info.ini");

$con = mysql_connect($DB_HostName,$DB_User,$DB_Pass);
if (!$con)
    {
    echo "接続に失敗しました。<br>";
    exit;
    }
if (! mysql_select_db($DB_Name,$con))
    {
    echo "DBのアクセスに失敗しました。<br>";
    mysql_close();
    exit;
    }

/*
echo "*** 成功したよ";
mysql_close();
exit();
*/

$id=get_input("id");
$type=get_input("type");
$value=get_input("value");

if ($type == "long" || $type == "string") {
    $DB_Table = $type."_table";
} else {
	$type = "long";
	$DB_Table = "long_table";
	$value = $value + 0;
}
if($type == "string") $value = "'".mysql_real_escape_string($value)."'";

$sql1 = "insert into $DB_Table(id,value) values('$id',$value)";
$sql2 = "update $DB_Table set value = $value where id='$id'";

$res = mysql_query($sql1,$con);
if ($res) {
    echo "S1:".$sql1;
} else {
	$res = mysql_query($sql2,$con);
    if ($res) {
    	echo "S2:".$sql2;
    } else {
		echo "E:".$sql2;
    }
}
mysql_close();
?>