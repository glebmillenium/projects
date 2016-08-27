<?php

/*
*			Скрипт сохраняет распределение физкультурных групп для преподавателя.
*			Является вспомогательным для ajax-запроса.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	$name_array = $_GET['js'];
	$names = json_decode($name_array,true);
	//var_dump($names);
	$ids = array();
	$nagrs = array();
	$initials = array();

	$hours = $_GET['hours'];

	$prep = iconv('utf-8','windows-1251',$names['prep']);
	unset($names['prep']);

	$initials = explode(' ',$prep);
	//var_dump($initials);
	
	for($i=0;$i<count($names);$i++)
	{
		$ids[$i] = $client->fiz_GetContingentID(iconv('utf-8','windows-1251',$names[$i]));
		if ($ids[$i] == -1)
		{
			echo "Error! Function fiz_GetContingentID  returns -1";
			exit();
		}
	}

	/*
	for($i=0;$i<count($ids);$i++)
	{
		$nagrs[$i] = $client->fiz_GetRaspnagrID($ids[$i]);
		if ($nagrs[$i] == -1)
		{
			echo "Error! Function fiz_GetRaspnagrID returns -1";
			exit();
		}
	}*/
	//var_dump($nagrs);

	$prep_id = $client->fiz_getPrepodID($initials[0],$initials[1],$initials[2]);
	if($prep_id == -1)
	{
		echo "Error! Function fiz_getPrepodID returns -1.";
		exit();
	}


	for($i=0;$i<count($ids);$i++)
	{
		
		$flag = $client->fiz_saveRaspred($prep_id,$ids[$i]);
		if ($flag == -1)
		{
			echo "Error in function fiz_saveRasped. Returns -1";
			exit();
		}
		//echo "CONT: ".$ids[$i]." EMP: ".$prep_id;

	}
	echo iconv('windows-1251','utf-8',"Распределение сохранено");



?>