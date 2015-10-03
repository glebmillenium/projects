<?php

/*
*			Скрипт возвращает нагрузку для преподавателя.
*			Является вспомогательным для ajax-запроса.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	$parts = preg_split('/\s+/', $_GET['js']);

	$dol = $client->fiz_GetPrepodDolzh(iconv('utf-8','windows-1251',trim($parts[0])),iconv('utf-8','windows-1251',trim($parts[1])),iconv('utf-8','windows-1251',trim($parts[2])));
	if ($dol == -1)
	{
		echo "Error! In function: fiz_GetPrepodDolzh (return -1)";
		exit();
	}
	else
	{
		$stav = $client->fiz_getPrepStavka(iconv('utf-8','windows-1251',trim($parts[0])),iconv('utf-8','windows-1251',trim($parts[1])),iconv('utf-8','windows-1251',trim($parts[2])));

		if($stav == -1)
		{
			echo "Error! In function: fiz_getPrepStavka (return -1)";
			exit();
		}
		else
		{
			//echo(iconv('windows-1251','utf-8',$stav));
			/*Далее определяются часы для разных должностей — приказ УМУ*/
			switch($dol)
			{
				case ($dol == 'Ст.преподаватель' || $dol == 'Доцент' || $dol == 'Ассистент'):
					$umunagr = 840*$stav;
					if($umunagr > 900)
						$umunagr = 900;
					break;
				case ($dol == 'Зав. кафедрой'):
					$umunagr = 700*$stav;
					if($umunagr > 900)
						$umunagr = 900;
					break;
				case ($dol == 'Профессор'):
					$umunagr = 760*$stav;
					if($umunagr > 900)
						$umunagr = 900;
					break;
			}

			echo $umunagr;
		}
	}


	//fiz_getPrepStavka


?>