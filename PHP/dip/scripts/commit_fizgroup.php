<?php

/*
*
*
*
*
*/


	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	global $current_semestr;

	$ids = array();
	$courses = array();


	$str = json_decode($_GET['js'],true);
	//var_dump($str);	
	//var_dump($_GET);

	/*Получаем ИД студгрупп и курсы*/
	foreach($str as $value)
	{
		$name = iconv('utf-8','windows-1251',$value);
		$struct = $client->fiz_GetStudGroupID($name);
		if ($struct == -1)
		{
			echo "Error! In function: fiz_GetStudGroupID (return -1).";
			exit();
		}

		array_push($ids, $struct['id']);
		array_push($courses, $struct['course']);
	}

	/*Определяем семестр для курса*/
	$kurs = $courses[0];
	if ($kurs > 1)
	{
		switch ($kurs)
		{
			case ($kurs == 2 && $current_semestr == 1):
				$semestr = 3;
				break;
			case ($kurs == 2 && $current_semestr == 2):
				$semestr = 4;
				break;
			case ($kurs == 3 && $current_semestr == 1):
				$semestr = 5;
				break;
			case ($kurs == 3 && $current_semestr == 2):
				$semestr = 6;
				break;
			case ($kurs == 4 && $current_semestr == 1):
				$semestr = 7;
				break;
			case ($kurs == 4 && $current_semestr == 2):
				$semestr = 8;
				break;
			case ($kurs == 5 && $current_semestr == 1):
				$semestr = 9;
				break;
			case ($kurs == 5 && $current_semestr == 2):
				$semestr = 10;
				break;
		};
	}
	else
		$semestr = $current_semestr;


	/*Определяем ИД родительского потока*/

	$cont_name = iconv('utf-8','windows-1251',$_GET['pname']);
	$cont_id = $client->fiz_GetContingentID($cont_name);

	if ($cont_id == -1)
	{
		echo "Error! In function: fiz_GetContingentID (return -1)";
		exit();
	}
	
	$name = iconv('utf-8','windows-1251',$_GET['name']);

	/*Пишем в базу*/
	
	$success = $client->fiz_WriteFizGroup($name,$cont_id,$ids);

	if ($success == -1)
	{
		echo "Error! In function: fiz_WriteFizGroup (return -1)";
		exit();
	}
	else
	{
		echo iconv('windows-1251','utf-8','Физкультурная группа добавлена');
	}

?>