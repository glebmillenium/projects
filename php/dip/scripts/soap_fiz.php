<?php

/*
*
*
*
*
*/


Header("Expires: 0");
Header("Last-Modified: " . gmdate("D, d M Y H:i:s") . " GMT");
Header("Cache-Control: no-cache, must-revalidate");
Header("Cache-Control: post-check=0,pre-check=0", false);
Header("Cache-Control: max-age=0", false);
Header("Pragma: no-cache");


include_once("../include/config_fiz.inc.php");

//создание SOAP-сервера
$server = new SoapServer(null, array('uri' => $url_name,
                                     'encoding' => "WINDOWS-1251"));


//подключение к бд
$conn   = ADONewConnection($db_driver);
$conn   -> PConnect($db_host,$db_user,$db_pass,$db_db);
//установка кодировки
$sql     = 'SET NAMES cp1251';
$conn   -> Execute($sql);
//использование русских дат
$sql     = "SET lc_time_names='ru_RU'";
$conn   -> Execute($sql);
//тест
$sql	= "SET AUTOCOMMIT=0";
$conn 	->Execute($sql);

include_once("../functions/func_fiz.php");

$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';

//func_fiz

$server->addFunction("fiz_GetPotokList");				//получение списка плановых потоков УМУ
$server->addFunction("fiz_GetSexSubgroups");			//получение списка студенческих подгрупп по половому признаку, входящих в плановый поток
$server->addFunction("fiz_GetContingentCourse");		//получение курса студентов, входящих в плановый поток УМУ
$server->addFunction("fiz_GetContingentID");			//получение ID потока студентов по имени потока
$server->addFunction("fiz_GetFizGroupAmount");			//получение рекомндуемого к созданию количества физ.групп
$server->addFunction("fiz_WriteFizGroup");				//записывает созданную ФГ в БД
$server->addFunction("fiz_GetStudGroupID");				//возвращает ID активной студенческой группы по её имени
$server->addFunction("fiz_getPrepodID");				//возвращает ID преподавателя
$server->addFunction("fiz_GetPrepodList");				//возвращает ФИО преподавателей указанной кафедры
$server->addFunction("fiz_GetPrepodDolzh");				//возвращает должность преподавателя
$server->addFunction("fiz_getPrepStavka");				//возвращает значение ставки для преподавателя
$server->addFunction("fiz_getFizGroups");				//возвращает список физкультурных групп и их курсов
$server->addFunction("fiz_DeactivateCont");				//делает неактивным поток
$server->addFunction("fiz_GetRaspnagrID");				//возвращает ID распределения нагрузки для физкультурной группы
$server->addFunction("fiz_saveRaspred");				//сохраняет распределение для преподавателя



$server->handle();

?>