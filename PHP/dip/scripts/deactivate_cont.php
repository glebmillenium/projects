<?php

/*
*			—крипт назначает флаг "неактивен" потоку, подгруппы которого распределены по физкультурным группам.
*			явл€етс€ вспомогательным дл€ ajax-запроса.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	$name = iconv('utf-8','windows-1251',$_GET['name']);


	
	$id = $client->fiz_GetContingentID($name);
	if ($id == -1)
	{
		echo "Error while updating select list: function fiz_GetContingentID returns -1!";
		exit();
	}
	else
	{
		$result = $client->fiz_DeactivateCont($id);
		if ($result == -1)
		{
			echo "Error while updating select list: function fiz_DeactivateCont returns -1!";
			exit();
		}
		else echo 1;		//успешно изменили
		
	}
	

?>