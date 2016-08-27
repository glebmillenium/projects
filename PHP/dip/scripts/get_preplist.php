<?php

/*
*			—крипт возвращает работников кафедры физкультуры.
*			явл€етс€ вспомогательным дл€ ajax-запроса.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	$html_string = '';

	//2 Ч ID кафедры физкультуры
	$prep = $client->fiz_GetPrepodList(2);

	if ($prep == -1)
	{
		echo 'Error! In function: fiz_GetPrepodList (return -1)';
		exit();
	}
	else
	{
		foreach($prep as $massiv)
		{
			$html_string = $html_string."<option>";
			foreach($massiv as $val)
				$html_string  = $html_string.$val." ";
			$html_string = $html_string."</option>";
		}

		echo iconv('windows-1251','utf-8',$html_string);
	}


?>