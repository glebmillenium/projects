<?php

	// Соединение с SOAP
	include('config.inc.php');

	$client =new SoapClient(null,array('location'=> $location,
             'uri' => $uri,
             'login' => $login,
             'password' => $pass,
             'encoding' => "WINDOWS-1251"));

	// Определение настроек по учебному процессу - начало
	$current_date        = date("d.m.Y");
	$current_year        = date("Y"); // текущий год
	if(date("m") < 9){
	  $current_semestr        = 2; // текущий семестр
	  $current_study_year        = $current_year - 1; // текущий учебный год (начало)
	 }
	else{
	  $current_semestr        = 1; // текущий семестр
	  $current_study_year        = $current_year; // текущий учебный год (начало)
	 }

?>