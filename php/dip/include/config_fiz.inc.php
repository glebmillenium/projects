<?php

$db_host       = 'localhost';
$db_user       = 'root';
$db_pass       = '';
$db_db         = 'fiz';
$db_driver		= 'mysql';


include('adodb/adodb.inc.php');
include('adodb/tohtml.inc.php');


$url_name	= 'http://localhost/soap/soap_asu.php';

// Определение настроек по учебному процессу - начало
$current_year   = date("Y"); // текущий год
if(1 < date("n") && date("n") < 8){
  $current_semestr      = 2; // текущий семестр
  $current_study_year   = $current_year - 1; // текущий учебный год (начало)
}
else{
   $current_semestr       = 1; // текущий семестр
   $current_study_year = $current_year; // текущий учебный год (начало)
   if (date("n") == 1) {
     $current_study_year--; // текущий учебный год (начало)
   }
}
// Определение настроек по учебному процессу - конец




?>