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

if ($type == "long" || $type == "string") {
    $DB_Table = $type."_table";
} else {
	$type = "long";
	$DB_Table = "long_table";
}

$sql = "select value FROM $DB_Table where id='$id'";
//echo $sql;

$res = mysql_query($sql,$con);
if ($res) {
    $row = mysql_fetch_array($res);
    if(isset($row[0])) echo "S:".$row[0];
    else echo "E:".$sql;
} else {
	echo "E:".$sql;
}
mysql_close();
?>