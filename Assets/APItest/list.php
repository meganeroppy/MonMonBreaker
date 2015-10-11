<html>
<HEAD>
<TITLE>Data Base Testページ</TITLE>
<META http-equiv="Content-Type" content="text/html; charset=x-sjis">
</HEAD>
<body>
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
}

$sql = "select * FROM $DB_Table order by id";

$res = mysql_query($sql,$con);

if ($res)
    {
    echo "<html>\n";
    echo "<body>\n";
    echo $sql." 成功<br>\n";

	if (strstr($sql,'select') || strstr($sql,'show'))
		{
	    echo "<table>\n";
	    for ($i=0;$row = mysql_fetch_array($res);$i++)
		    {
		    echo "<TR>";
			echo "<TD>$i : </TD>";
		    for ($j = 0 ; $row[$j]; $j++)
		        {
		        echo "<TD>";
		        echo $row[$j];
		        echo "</TD>";
		        }
		    echo "</TR>\n";
		    }
	    echo "</table>\n";
    	mysql_free_result($res);
	    }
	echo "</body>\n";
    echo "</html>\n";
    }
else{
    echo "<html>\n";
    echo "<body>\n";
    echo "Error can not get sql [$sql]";
    echo "</body>\n";
    echo "</html>\n";
    }

mysql_close();

?>
</body>
</html>