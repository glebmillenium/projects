$(document).ready(function (){

	$('#note').hide();

	var toggleFlag;

	/*============================================== ФУНКЦИИ ==============================================*/

	function box_Load() {
		$('.prepblock').html('<h2>Иванов Иван Иванович</h2><img class="saveicon_prep" title="Сохранить распределение"" width="20px" height="20px" src="./images/ok.png"/><img class="editicon_prep" title="Редактировать распределение" width="20px" height="20px" src="./images/pen.png"/><p>Должность: <span id="dol"></span></p><p>Нагрузка: <span id="nagr"></span></p><progress value="0" max="100"></progress><p id="percent">0 ч.</p><div class="inside"></div>');
	}


	function forceSelect() {
		$('#prep:first-child').find('option:first').prop('selected',true);
	}

	function nextSelect() {
		$('option:selected').next().prop('selected',true);
	}

	//function deleteRasp()

	function handleClicker(dad,id) {
		var spanContent = $('span').eq(id).text();
		var mommy = $(".subgroup:contains('"+spanContent+"')");
		var donor2 = mommy.text();
		mommy.show('fade',300);
		$('span').eq(id).remove();

		currentValue = dad.find('progress').attr('value');
		var optimal = dad.find('progress').attr('max');

		startcut = donor2.indexOf('[');
		endcut = donor2.indexOf(' ч');
		addition = donor2.substring(startcut+1,endcut);
		newValue = Number(currentValue) -  Number(addition);
		dad.find('progress').attr('value',newValue);
		if (newValue > optimal)
		{
			dad.find('#percent').css('color','red');
			dad.find('h2').css('color','red');
			dad.css('border-style','solid');
			dad.css('border-color','red');
		}
		else 
		{
			dad.find('#percent').css('color','black');
			dad.find('h2').css('color','black');
			dad.css('border-style','dashed');
			dad.css('border-color','black');
		}

		dad.find('#percent').text(newValue+" ч.");
		dad.find('progress').attr('value',newValue);

	}

	function box_release() {
		var col = $('.desc').length;
		var id;
		for(i=0;i<col;i++)
		{
			id = $('.desc').index();
			var spanContent = $('.desc').eq(id).text();
			var mommy = $(".subgroup:contains('"+spanContent+"')");
			mommy.show('fade',300);
			$('.desc').eq(id).remove();
			$('.prepblock').find('h2').css('color','black');
			$('.prepblock').css('border-style','dashed');
			$('.prepblock').css('border-color','black');
		}
	}

	function do_draggable() {
		$('.subgroup').draggable({ 
			revert: true,
			stack: ".subgroup",
			containment:"#wrapper",
			scroll:false
		});
	}

	function do_droppable() {
		$('.prepblock').droppable({
			drop:function(event,ui){
				
				var startcut,vstavka,newValue;
				var donor = $(ui.draggable).text();
								
				var currentValue = $(this).find('progress').attr('value');
				var maxValue = Number($(this).find('progress').attr('max'));
				
				startcut = donor.indexOf('[');
				endcut = donor.indexOf(' ч');
				addition = donor.substring(startcut+1,endcut);

				vstavka = donor.substring(0,donor.indexOf('['));
				$("<span class='desc'>").appendTo('.inside').text(vstavka);

				newValue = Number(currentValue) +  Number(addition);
				$("#percent").text(newValue+" ч.");
				$(this).find('progress').attr('value',newValue);
					
					if (newValue > maxValue)
					{
						$(this).find('#percent').css('color','red');
						$(this).find('h2').css('color','red');
						$(this).css('border-style','solid');
						$(this).css('border-color','red');
					}
					else 
					{
						$(this).find('#percent').css('color','black');
						$(this).find('h2').css('color','black');
						$(this).css('border-style','dashed');
						$(this).css('border-color','black');
					}

				$(ui.draggable).hide('fade',200);
			}
		});
	}

	function editRasp() {
		toggleFlag = undefined;
		$('.prepblock').find('img.editicon_prep').click(function (){
			$(this).attr('src','./images/pen_edited.png').css('border-color','red');
			var daddy = $(this).parent();
			//если кликнули первый раз или ещё не кликали
			if (toggleFlag == 0 || typeof(toggleFlag)=='undefined')
			{
				$('.inside').find('span.desc').css({
					'text-decoration':'underline',
					'cursor':'pointer',
					'color':'#66ccff'});
				clickCounter = 1;
				//обработка события нажатия на редактируемую группу
				$('.inside').find('span.desc').click(function (){
					spanID = $('span').index(this);

					if (clickCounter == 0)
					{
						$('span').unbind('click');
					}
					else
					{
						clickCounter = 1;
						$('span:eq(spanID)').bind('click',handleClicker(daddy,spanID));
					}
				});
				toggleFlag = 1;

			}
			//если уже включали режим редактирования
			else if (toggleFlag == 1)
			{
				clickCounter = 0;
				$(this).attr('src','./images/pen.png').css('border-color','black');
				$('.inside').find('span.desc').css({
					'text-decoration':'none',
					'cursor':'default',
					'color':'black'});
				$('.inside').find('span.desc').click(function (){
					spanID = $('span').index(this);
				});
				toggleFlag = 0;
			}
		});
	}

	function list_loadFizgroups() {
		var ajaxResult = $.ajax({
			url: './scripts/get_fizgroups.php',
			dataType: 'html',
			success: function(data) {
				$('.list-items').html(data);
				do_draggable();
			},
			error: function() {
				alert('Ошибка при загрузке физкультурных групп');
			}
		});
	}

	function box_loadDolzhn(string) {
		var ajaxResult = $.ajax({
			type: "GET",
			url: './scripts/get_prepdolzh.php',
			data: {js:string},
			dataType: 'html',
			success: function(data) {
				$('#dol').text(data);
			},
			error: function() {
				alert('Ошибка при загрузке должности.');
			}
		});
	}

	function box_loadNagr(string) {
		var ajaxResult = $.ajax({
			type: "GET" ,
			url: './scripts/get_prepnagr.php',
			data: {js: string},
			dataType: 'html',
			success: function(data) {
				$('#nagr').text(data+" ч.");
				$('.prepblock').find('progress').attr('max',data);
			}
		});
	}

	function box_loadPrepodName() {
		nameString = $('#prep').find('option:selected').text();
		$('.prepblock').find('h2').text(nameString);
	}

	function add_ReadyRasp() {
		var readyPrep = $('.prepblock').find('h2').text();
		$('#saved').show();
		$('<div class="ready-item">'+readyPrep+'<img class="return" src="./images/1pen.png" width = "18px" height="18px" /></div>').appendTo('#ready');

	}

	function deleteFromRasp() {
		$('.desc').remove();
		$('.prepblock').find('progress').attr('value',0);
		$('#percent').text('0 ч.');
	}

	function restorePrep(thisDiv) {
		var whatsName = thisDiv.text();
		alert(whatsName);
	}


	function saveRasp() {
		var limiter = $('.desc').length;
		var id,spanContent,jsonString;
		var nameEmp = $('.prepblock').find('h2').text();
		var hoursText = $('#percent').text();
		var go = hoursText.indexOf(' ч.');
		var curHours = hoursText.substring(0,go);

		if(limiter == 0)
			jsonString = '';
		else
		{
			jsonString = '{"prep":"'+nameEmp+'",';
			for(i=0;i<limiter;i++)
			{
				//id = $('.desc').index();
				spanContent = $('.desc').eq(i).text();
				jsonString = jsonString + '"'+i+'"'+':'+'"'+spanContent+'"';
				if (i != limiter-1)
					jsonString = jsonString + ",";
			}
			jsonString = jsonString+"}";
		}
		var ajaxSave = $.ajax({
			type: "GET",
			url: "./scripts/save_raspnagr.php?hours="+curHours,
			data: {js:jsonString},
			dataType: "html",
			success: function(data) {
				alert(data);
			},
			error: function() {
				alert('Не удалось сохранить распределение');
			},
			complete: function() {
				add_ReadyRasp();
				deleteFromRasp();
				$('#prep').find('option:contains("'+nameEmp+'")').hide();
				nextSelect();
				box_loadPrepodName();
				var curName = $('#prep').find('option:selected').text();
				box_loadDolzhn(curName);
				box_loadNagr(curName);
				do_droppable();
				//editRasp();
			}
		});
	}



	/*=====================================================================================================*/
	$('#saved').hide();

	$('#prep').load('./scripts/get_preplist.php',function (){

			//box_Load();
			forceSelect();
			box_loadPrepodName();
			var curName = $('#prep').find('option:selected').text();
			box_loadDolzhn(curName);
			box_loadNagr(curName);
			do_droppable();
			//editRasp();
			/*$('.saveicon_prep').click(function() {
				saveRasp();
			});*/
	});

	$('#prep').change(function() {
			box_release();
			box_Load();
			box_loadPrepodName();
			var curName = $('#prep').find('option:selected').text();
			box_loadDolzhn(curName);
			box_loadNagr(curName);
			do_droppable();
			editRasp();
			$('.saveicon_prep').click(function() {
				saveRasp();
			});
	});


	box_Load();
	list_loadFizgroups();
	editRasp();

	/*Вызов подсказки*/
	$('.question').click(function (){
		$('#note').show();
	});

	/*Скрытие подсказки по клику в любом месте*/
	$('#wrapper').click(function (){
		$('#note').hide();		
	});

	$('.saveicon_prep').click(function() {
		saveRasp();
	});

	$('.return').click(function() {
		alert($(this).parent().tagName);
		//restorePrep($(this).parent());
	});






});