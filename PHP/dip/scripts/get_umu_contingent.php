<?php

	/*
	*	������ ��� ������ ���� �������� ������� ��� �� ������� �������.
	*	��������������� ������, ���������� ������ ��� AJAX-�������.
	*
	*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	global $current_study_year;


	$cont_list = $client->fiz_GetPotokList($_GET['kurs'],$current_study_year);
	$html_string = '';

	if ($cont_list != -1)
	{

		for ($i=0;$i<count($cont_list);$i++)
			$html_string = $html_string."<option>".$cont_list[$i]."</option>\n";
			
			echo(iconv('windows-1251','utf-8',$html_string));
	}
	else echo (iconv('windows-1251','utf-8',"<option>������ � �������</option>"));

?>