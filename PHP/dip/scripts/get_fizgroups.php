<?php

/*
*			—крипт возвращает список физкультурных групп с группировкой по курсам.
*			явл€етс€ вспомогательным дл€ ajax-запроса.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	$htmlString = '';

	$fgroups = $client->fiz_getFizGroups();

	if($fgroups == -1)
	{
		echo "Error! In function: fiz_getFizGroups (returns -1)";
		exit();
	}
	elseif($fgroups == 0)
	{
		echo "Error! Function: fiz_getFizGroups returns 0 rows";
		exit();
	}
	else
	{
		$prev = $fgroups[0]['kurs'];
		$htmlString = $htmlString."<div class='umugroup'><span>".$fgroups[0]['kurs']." курс</span></div>";
		for ($i=0;$i<count($fgroups);$i++)
		{
			if ($fgroups[$i]['kurs'] != $prev)
			{
				$htmlString = $htmlString."<div class='umugroup'><span>".$fgroups[$i]['kurs']." курс</span></div>";
			}
			$htmlString = $htmlString."<div class='subgroup'>".$fgroups[$i]['name']."<span class='amount'>[".$fgroups[$i]['hours']." ч.]</span></div>";
		}
		echo iconv('windows-1251','utf-8',$htmlString);
		//fiz_getFizGroups
	}


?>