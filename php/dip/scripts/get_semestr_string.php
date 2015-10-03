<?php

	/*
	*		Скрипт для вывода названия текущего семестра.
	*		Является вспомогательным для ajax-запроса.
	*
	*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');
	
	if ($current_semestr == 1)
		echo " (осенний семестр ".$current_study_year.")";
	elseif ($current_semestr == 2)
		echo " (весенний семестр ".$current_study_year.")";

?>