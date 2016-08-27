<?php

/*
*		������ ���������� ������ ������������ �����, ���������� �� 
*		��������� �� ����.
*		������ �������� ��������������� ��� AJAX-��������.
*/

	include_once('soap_fiz.php');
	include('../include/header.inc.php');

	global $current_semestr;

	/*
	*	����������� ������ �������� �������� (1 � 7) ��� ��������� ������� ������.
	*/

	$cont_name = iconv('utf-8','windows-1251',$_GET['name']);
	
	$cont_id = $client->fiz_GetContingentID($cont_name);

	//echo $cont_id;


	if ($cont_id == -1)
	{
		echo "Error! Function: fiz_GetContingentID.";
		exit();
	}

	$kurs = $client->fiz_GetContingentCourse($cont_id);
	if ($kurs == -1)
	{
		echo "Error! In function: fiz_GetContingentCourse! ";
		exit();
	}

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

	/*��������� ������ �������� � ����������� ������ � �������*/

	$subgroups = $client->fiz_GetSexSubgroups($cont_id,$semestr);

	if ($subgroups == -1)
	{
		echo "������ ��� ���������� ������� fiz_GetSexSubgroups!";
		exit();
	}
	
	//����� ������ ��������
	if ($_GET['flag'] == 1)
	{
		echo "<div class='umugroup'>
					<span></span> <span id='amount'></span>
				</div>";

		for ($i = 0; $i < count($subgroups); $i++)
		{
			echo (iconv('windows-1251','utf-8',"<div class='subgroup'>".$subgroups[$i]['group']." � (".$subgroups[$i]['mal'].")</div>"));
			echo (iconv('windows-1251','utf-8',"<div class='subgroup girls'>".$subgroups[$i]['group']." � (".$subgroups[$i]['dev'].")</div>"));
		}
	}
	//����� ������ ���.�����
	elseif ($_GET['flag'] == 0)
	{
		$sum_stud = 0;
		for ($i = 0;$i < count($subgroups); $i++)
		{
			$sum_stud += $subgroups[$i]['mal'];
			$sum_stud += $subgroups[$i]['dev'];
		}
		
		$aver = $client->fiz_GetFizGroupAmount ($cont_id);

		if ($aver == -1)
		{
			echo "Error! in function fiz_GetFizGroupAmount.";
			exit();
		}

		$limit = round($sum_stud / $aver);

		for ($i = 1; $i <= $aver; $i++)
		{
			echo iconv('windows-1251','utf-8',"<div class='fizgroup'>
				<h2>��� �������� " .$i."</h2>
				<img class='saveicon' title='���������' width='20px' height='20px' src='./images/ok.png'/>
				<img class='editicon' title='�������������' width='20px' height='20px' src='./images/pen.png'/>
				<img class='deleteicon' title='�������' width='20px' height='20px' src='./images/trash.png'/>
				<p class='desc'></p>
				<progress value='0' max='{$limit}'></progress>
				<p class='progvalue'>0</p>
			</div>");
		}

	}

?>