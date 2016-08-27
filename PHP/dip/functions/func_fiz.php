<?php

/*
=pod

=head1 func_fiz - файл с функциями для работы с физкультурными группами

=head2 fiz_GetPotokList

=over 1

=for troff

	Функция fiz_GetPotokList() формирует список названий плановых потоков УМУ на текущий семестр.
	Входные данные:
	$kurs 		— курс студентов потока;
	$year 		— текущий учебный год.
	Параметр $kurs может содержать два значения:
		0 		— выбрать потоки всех курсов;
		1 		— выбрать потоки только 1го курса.
 	Выходные данные:
 	В случае успешного выполнения возвращает ассоциативный массив с названиями плановых потоков.

 	В случае неудачи возвращает значение -1.
  

 Автор: Алексеев К.А.
 Дата : 16.05.2013

=back

=cut
   
*/

function fiz_GetPotokList ($kurs,$year)
{
	global $conn;

	$potoks = array();
	$i = 0;

	if ($kurs == 0)
		$query = "SELECT DISTINCT c.name				
					FROM contingent c";
	else 
	{
		$query = "SELECT DISTINCT c.name
				FROM contingent c
				INNER JOIN list_cont lc ON lc.cont_id = c.id
				JOIN stud_groups sg ON lc.group_id = sg.id
				INNER JOIN courses cr ON cr.group_id = sg.id
				WHERE c.stype_id = '4' AND c.active = '1' AND cr.course ={$kurs}
				AND cr.archived_id IN (0,10)
				AND cr.s_year = {$year}";
	}
	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		while ($row = $result->FetchRow())
		{
			array_push($potoks,$row['name']);
			$i++;
		}
		return $potoks;
	}
	else return -1;

}

/*
=pod

=head1 func_fiz - файл с функциями для работы с физкультурными группами

=head2 fiz_GetSexSubgroups($contingent,$current_semestr)

=over 1

=for troff

	Функция fiz_GetSexSubgroups формирует список студенческих подгрупп, разделённых
	по половому признаку с указанием количества юношей и девушек. Количество юношей и 
	девушек указывается для текущего семестра, записи о студентах, которые отчислены,
	находятся в академическом отпуске.
	Входные данные:
		- ID планового потока УМУ;
		- номер текущего семестра;
	Выходные данные в случае успешного выполнения запроса : 
		двумерный ассоциативный массив со структурой вида 
		[group][mal][dev],
		где group — ID студенческой группы,
			mal   — количество юношей в указанной группе,
			dev   — количество девушек в указанной группе.
	Выходные данные в случае неуспешного выполнения запроса или возврата пустого результата:
		возвращается число -1.
  
   
 Автор: Алексеев К.А.
 Дата : 16.05.2013

=back

=cut
   
*/

function fiz_GetSexSubgroups ($contingent,$current_semestr)
{
	global $conn;
	$subgroups = array();
	$query = "SELECT  stud_groups.name,lc.group_id,
													(
														SELECT count(*)
														FROM courses cr
														INNER JOIN stud_groups sg ON cr.group_id = sg.id
														INNER JOIN students st ON cr.stud_id = st.id
														WHERE st.sex = 1
														AND sg.id = lc.group_id
														AND cr.semestr = {$current_semestr}
														AND (cr.archived_id = 10 OR cr.archived_id = 0 OR cr.archived_id = 7)
													) AS mal,
													(
														SELECT count(*)
														FROM courses cr
														INNER JOIN stud_groups sg ON cr.group_id = sg.id
														INNER JOIN students st ON cr.stud_id = st.id
														WHERE st.sex = 2
														AND sg.id = lc.group_id
														AND cr.semestr = {$current_semestr}
														AND (cr.archived_id = 10 OR cr.archived_id = 0 OR cr.archived_id = 7)
													) AS dev
				FROM list_cont lc
					INNER JOIN  contingent c ON lc.cont_id = c.id
					INNER JOIN stud_groups ON lc.group_id = stud_groups.id
				WHERE c.id = ".$contingent;
	 
	$result = $conn->Execute($query);
	if ($result && ($result->RecordCount() > 0))
	{
		while ($row = $result->FetchRow())
		{
			array_push($subgroups, array (
											'group' => $row['name'],
											'mal' => $row['mal'],
											'dev' => $row['dev']
										));
		}
		return $subgroups;
	}
	else return -1;
}

/*
=pod

=head1 func_fiz - файл с функциями для работы с физкультурными группами

=head2 fiz_getContingentCourse ($contingent)

=over 1

=for troff

	Функция fiz_getContingentCourse  возвращает номер курса, на котором обучаются
	студенты, входящие в плановый поток.
	Входные данные:
		- ID планового потока УМУ;
	Выходные данные:
		- номер курса (при успешном выполнении),
		- число -1 (при ошибочном результате запроса),
		- число 0 (при возвращении нескольких значений: свидетельствует о некорректности данных
			в таблице courses [указан неверный курс для одной из групп, входящих в плановый поток],
			либо в таблице list_cont [группа связана с некорректным потоком]).
  
   
 Автор: Алексеев К.А.
 Дата : 16.05.2013

=back

=cut
   
*/

/*function fiz_GetContingentCourse ($contingent)
{

	global $conn;

	$query = "SELECT DISTINCT course FROM courses c
				INNER JOIN stud_groups sg ON c.group_id = sg.id
				INNER JOIN list_cont lc ON lc.group_id = sg.id
				WHERE lc.cont_id = '{$contingent}'";
	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		if ($result->RecordCount() == 1)
			{
				$row = $result->FetchRow();
				return $row['course'];
			}
		else return 0;
	}
	else return -1;
}*/

function fiz_GetContingentCourse ($contingent)
{

	global $conn;
	global $current_study_year;

	$query = "SELECT DISTINCT enteryear FROM stud_groups sg
				INNER JOIN list_cont lc ON lc.group_id = sg.id
				WHERE lc.cont_id = '{$contingent}'";
	$result = $conn->Execute($query);
	if ($result && ($result->RecordCount() > 0))
	{
		if ($result->RecordCount() == 1)
			{
				$row = $result->FetchRow();
				return $current_study_year-$row['enteryear']+1;
			}
		else return 0;
	}
	else return -1;
}


/*



*/

function fiz_GetContingentID ($cont_name)
{

	global $conn;

	$query = "SELECT id FROM contingent WHERE name ='{$cont_name}'";
	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		$row = $result->FetchRow();
		return $row['id'];
	}
	else return -1;
}


/*
*
*/

function fiz_GetFizGroupAmount ($contingent)
{

	global $conn;

	$query = "SELECT num_fg FROM raspnagr WHERE cont_id = {$contingent}";

	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		$row = $result->FetchRow();
		return $row['num_fg'];
	}
	else return 15;//che eto?
}


/*
*
*
*/

function fiz_WriteFizGroup($group_name,$cont,$group_ids) 
{

	global $conn;
	$last_cont_id = 0;
	$i = 0;

	$query = "START TRANSACTION";
	$result = $conn->Execute($query);
	$query = "INSERT INTO contingent (id,name,stype_id,parent_id)
				VALUES (NULL,'{$group_name}',3,{$cont})";
	$query2 = "SELECT LAST_INSERT_ID() AS lid";
	$result = $conn->Execute($query);
	$result2 = $conn->Execute($query2);
	if ($result && $result2)
	{
		$row = $result2->FetchRow();
		$last_cont_id = $row['lid'];
		for ($i=0;$i<count($group_ids);$i++)
		{
			$query3 = "INSERT INTO list_cont (group_id,cont_id)
						VALUES ({$group_ids[$i]},{$last_cont_id})";
			$result3 = $conn->Execute($query3);
			if(!$result3)
			{
				$conn->Execute("ROLLBACK");
				return -1;
			}
		}
		$conn->Execute("COMMIT");
		return 1;
	}
	else
	{
		$conn->Execute("ROLLBACK");
		return -1;
	}
}


/*

*
*
*/

function fiz_GetStudGroupID($group)
{
	global $conn;
	$id_array = array();

	$query = "SELECT DISTINCT s.id, c.course
				FROM courses c 
				INNER JOIN stud_groups s
				ON c.group_id = s.id
				WHERE s.name='{$group}' 
				AND s.archived_id IN (0,10,7) 
				AND s.studyform_id IN (1,2,3)";

	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		$row = $result->FetchRow();
		$id_array['id'] = $row['id'];
		$id_array['course'] = $row['course'];
		return $id_array;
	}
	else return -1;
}



/*
*
*
*
*
*
*/

function fiz_getPrepodID($fam,$im,$ot)
{

	global $conn;

	$query = "SELECT id FROM employes 
				WHERE name1 = '{$fam}'
				AND name2 = '{$im}'
				AND name3 = '{$ot}'";

	$result = $conn->Execute($query);

	if($result && ($result->RecordCount()))
	{
		$row = $result->FetchRow();
		return $row['id'];
	}
	else return -1;

}



/*
*
*
*
*/

function fiz_GetPrepodList($kaf_id)
{
	global $conn;

	$emp = array();

	$query = "SELECT name1,name2,name3
				FROM employes
				WHERE kaf_id = {$kaf_id}
				ORDER BY name1";

	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		while ($row = $result->FetchRow())
		{
			array_push($emp, array(
									'name1' => $row['name1'],
									'name2' => $row['name2'],
									'name3' => $row['name3']
				));
		}
		return $emp;
	}
	else return -1;

}



/*
*
*
*
*/

function fiz_GetPrepodDolzh($fam,$im,$ot) {

	global $conn;

	$query = "SELECT d.name
				FROM dolzn d
				INNER JOIN employes e ON e.emp_dol_id = d.id
				WHERE e.name1 ='{$fam}'
				AND e.name2 = '{$im}'
				AND e.name3 = '{$ot}'";

	$result = $conn->Execute($query);

	if ($result && ($result->RecordCount() > 0))
	{
		$row = $result->FetchRow();
		return $row['name'];
	}
	else return -1;

}


/*
*	
*
*
*/

function fiz_getPrepStavka($fam,$im,$ot) {

	global $conn;
	
	$query = "SELECT stavka FROM employes 
				WHERE name1 = '{$fam}'
				AND name2 = '{$im}'
				AND name3 = '{$ot}'";

	$result = $conn->Execute($query);

	if($result && ($result->RecordCount() > 0))
	{
		$row = $result->FetchRow();
		return $row['stavka'];
	}
	else return -1;
}

/*
*
*
*
*/

function fiz_getFizGroups() {

	global $conn;
	$fgroups = array();

	$query = "SELECT DISTINCT c.name,cr.course,r.amount
				FROM contingent c
				INNER JOIN list_cont lc ON lc.cont_id = c.id
				INNER JOIN courses cr ON lc.group_id = cr.group_id
				INNER JOIN raspnagr r ON r.cont_id = c.parent_id
				WHERE c.stype_id = 3 AND c.active = 1
				AND cr.semestr = (
						SELECT MAX(courses.semestr)
						FROM courses
						WHERE group_id = lc.group_id
						)
				ORDER BY course";

	$result = $conn->Execute($query);

	if($result)
	{
		if($result->RecordCount() > 0)
		{

		while ($row = $result->FetchRow())
			array_push($fgroups, array(
										'name' => $row['name'],
										'kurs' => $row['course'],
										'hours' =>$row['amount']
						));
		return $fgroups;
		}
		else return 0;
	}
	else return -1;
}

/*
*
*
*
*
*/

function fiz_DeactivateCont($cont_id)
{

	global $conn;

	$sql = "START TRANSACTION";
	$conn->Execute($sql);
	$query = "UPDATE contingent c
				SET c.active = 0
				WHERE c.id = {$cont_id}";

	$result = $conn->Execute($query);

	if($result)
	{
		$conn->Execute("COMMIT");
		return 1;
	}
	else 
	{
		$conn->Execute("ROLLBACK");
		return -1;
	}
}


/*
*
*
*
*
*/

function fiz_GetRaspnagrID($cont) {

	global $conn;

	$query = "SELECT DISTINCT r.id
				FROM raspnagr r
				INNER JOIN contingent c ON r.cont_id = c.id
				WHERE r.cont_id = (
					SELECT parent_id 
					FROM contingent 
					WHERE id={$cont}
						)";
	$result = $conn->Execute($query);

	if($result && ($result->RecordCount() > 0))
	{
		$row = $result->FetchRow();
		return $row['id'];
	}
	else return -1;
}


/*
*
*
*
*
*
*/

function fiz_saveRaspred($emp,$cont) {

	global $conn;

	$conn->Execute("START TRANSACTION");
	$query = "INSERT INTO rasphours (cont_id,emp_id,active)
				VALUES ({$cont},{$emp},1)";
	$result = $conn->Execute($query);

	if($result)
	{
		$conn->Execute("COMMIT");
		return 1;
	}
	else
	{
		$conn->Execute("ROLLBACK");
		return -1;	
	} 

}



?>