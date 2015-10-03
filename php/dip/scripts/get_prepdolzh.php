<?php

/*
*			—крипт возвращает работников кафедры физкультуры.
*			явл€етс€ вспомогательным дл€ ajax-запроса.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	$html_string = '';
	$parts = preg_split('/\s+/', $_GET['js']);
	//var_dump($parts);
	

	$dol = $client->fiz_GetPrepodDolzh(iconv('utf-8','windows-1251',trim($parts[0])),iconv('utf-8','windows-1251',trim($parts[1])),iconv('utf-8','windows-1251',trim($parts[2])));
	if ($dol == -1)
	{
		echo "Error! In function: fiz_GetPrepodDolzh (return -1)";
		exit();
	}
	else
	{
		echo iconv('windows-1251','utf-8',$dol);
	}


?>