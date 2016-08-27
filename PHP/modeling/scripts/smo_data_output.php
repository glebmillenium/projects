<?php
header('Content-type: text/plain; charset=utf-8'); 
require_once('./classes/SMO.php');
$obj = new SMO($_REQUEST['chanels'],$_REQUEST['lambda'],$_REQUEST['t_obs'],$_REQUEST['n']);
$output=array();
$output=$obj->probability();$truncate=3;
if(!empty($_REQUEST['truncate']))$truncate=round($_REQUEST['truncate']);
	
	echo "Вероятность того, что обслуживанием занят: \n\n";	
	foreach($output['chanel'] as $k=>$v) {
		echo $k." канал(а): ".round($v,$truncate)."\n";
	}
	echo "\n";
	
	echo "Доля выполненных заявок (Относительная пропускная способность): ".round($output['success']*100,$truncate)."%\n";
	echo "Доля отказанных заявок: ".round($output['fail']*100,$truncate)."%\n";
	echo "Абсолютная пропускная способность: ".round($output['abs'],$truncate)." заявок/мин\n";
	echo "Среднее число ЭВМ, занятых обслуживанием: ".round($output['average_chanels'],$truncate)." канала";

?>