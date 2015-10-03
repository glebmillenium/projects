$(document).ready(function(){

	$('#note').hide();

	var toggleFlags = new Array();
	var drags = new Array();
	var thisGender = new Array();
	var curIndex,i;
	var clickCounter;
	var max;


	function forceSelect() {
		$('#umuselect').find('option:first').prop('selected',true);
	}
	
	/*Смена названия потока в блоке и количества часов при выборе селектора*/
	$("#umuselect").change(function () {
		var str = $("#umuselect option:selected").text();
		var idstr = $('#umuselect option:selected').index();
		//alert(idstr);

		$('div.list-items').load('./scripts/get_subgroups.php?name='+str+'&flag=1',function (){
			//подгрузка подгрупп
			$('.subgroup').draggable({ 
			revert: true,
			stack: ".subgroup",
			containment:"#wrapper",
			scroll:false
			});
			//подгрузка названия потока 
			$("div.umugroup").find('span').not('#amount').text(str);
			var url = './scripts/get_umu_contingent.php?flag=' + String(idstr);
			$('span#amount').load(url,function (){

				//подгрузка физкультурных групп
				$('div#fizgroups').load('./scripts/get_subgroups.php?name='+str+'&flag=0',function () {

					var optimal = $('.fizgroup:first').find('progress').attr('max');
					$('#orient').text(optimal);

					/*Изменение названия физкультурной группы*/
					$('.fizgroup').find('h2').click(function (){
						var newNameFG = prompt('Введите название физкультурной группы: ');
						if (newNameFG != '')
							$(this).text(newNameFG);
					});

					/*Сохранение ФГ*/
					$('.fizgroup').find('img.saveicon').click(function (){
						var deleteStatus = 0;
						var papka = $(this).parent();
						var n = $(this).parent().find('span.desc').length;
						if (n == 0)
							alert('Не добавлена ни одна подгруппа!');
						else 
						{
							var jsonString = '{';
							for (i=0;i<n;i++)
							{
								var cutName;		
								var go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' М (');
								if (!(go+1))
									go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' Ж (');;
								cutName = ($(this).parent().find('span.desc').eq(i).text()).substring(0,go);
								jsonString += '"name'+i+'":"'+cutName+'"';
								if ($(this).parent().find('span.desc').eq(i).index() != $(this).parent().find('span.desc').eq(n-1).index())
									jsonString += ',';

							}
							jsonString += '}';
							//alert(jsonString);
							var papaName = $(this).parent().find('h2').text();
							var contName = $('.umugroup').find('span').not('#amount').text();
							var commitAjax = $.ajax({
								type: "GET",
								url:'./scripts/commit_fizgroup.php?name='+papaName+'&pname='+contName,
								data:{js:jsonString},
								dataType:"html",
								success: function (data){
									alert(data);
									deleteStatus = 1;
								},
								error: function (data){
									if (data == '-1')
										alert('Failed to load data');
								},
								complete: function(){
									if(deleteStatus == 1)
										{
											papka.remove();

											alert(m);
										}
								}
							});

							//если не осталось ни одной физгруппы (все сохранили)
						}
					});

					/*Режим редактирования физкультурной группы*/
						$('.fizgroup').find('img.editicon').click(function (){
						$(this).attr('src','./images/pen_edited.png').css('border-color','red');
						curIndex = $(this).index();
						var daddy = $(this).parent();
						//если кликнули первый раз или ещё не кликали
						if (toggleFlags[curIndex] == 0 || typeof(toggleFlags[curIndex])=='undefined')
						{
							
							handleClicker = function(dad,id) {
								var spanContent = $('span').eq(id).text();
								$(".subgroup:contains('"+spanContent+"')").show('fade',300);
								$('span').eq(id).remove();

								currentValue = dad.find('progress').attr('value');

								startcut = spanContent.indexOf('(');
								endcut = spanContent.indexOf(')');
								addition =spanContent.substring(startcut+1,endcut);
								newValue = Number(currentValue) -  Number(addition);
								dad.find('progress').attr('value',newValue);
								if (newValue > optimal)
								{
									dad.find('p.progvalue').css('color','red');
									dad.find('h2').css('color','red');
									dad.css('border-style','solid');
								}
								else 
								{
									dad.find('p.progvalue').css('color','black');
									dad.find('h2').css('color','black');
									dad.css('border-style','dashed');
								}

								dad.find('p.progvalue').text(newValue);
								dad.find('progress').attr('value',newValue);

								var thisIndex = dad.index();
								if (dad.find('span.desc').length == 0)
									drags[thisIndex] = 0;

							}

							daddy.find('span.desc').css({
								'text-decoration':'underline',
								'cursor':'pointer',
								'color':'#66ccff'});
							clickCounter = 1;
							//обработка события нажатия на редактируемую группу
							daddy.find('span.desc').click(function (){
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
							toggleFlags[curIndex] = 1;

						}
						//если уже включали режим редактирования
						else if (toggleFlags[curIndex] == 1)
						{
							clickCounter = 0;
							$(this).attr('src','./images/pen.png').css('border-color','black');
							daddy.find('span.desc').css({
								'text-decoration':'none',
								'cursor':'default',
								'color':'black'});
							daddy.find('span.desc').click(function (){
								spanID = $('span').index(this);
							});
							toggleFlags[curIndex] = 0;
						}
					});

					
					/*Удаление физкультурной группы*/
					$('.fizgroup').find('img.deleteicon').click(function (){
						if (confirm('Вы действительно хотите удалить ФГ "'+$(this).parent().find('h2').text()+'"'))
							{
								var parentDiv = $(this).parent();
								var restoreSubLen = parentDiv.find('span.desc').length;
								for (i=0;i<restoreSubLen;i++)
								{
									spanContent = parentDiv.find('span.desc').eq(i).text();
									//alert(spanContent);
									$(".subgroup:contains('"+spanContent+"')").show('fade',300);
									$('span').eq(i).hide('fade',300);
									$('span').eq(i).remove();
								}
								$(this).parent().hide('fade',300);
								$(this).parent().remove();
							}
					});

					$('.fizgroup').droppable({
						drop:function(event,ui){
							
							/*определяем пол*/
							thisIndex = $(this).index();
							var curGender;
							
							drags[thisIndex]++;
							donor = $(ui.draggable).text();
							var donor,startcut,newValue;
							
							if (drags[thisIndex] <= 1)
							{
								if (donor.indexOf('М (')!= -1)
									thisGender[thisIndex] = 1;
								if (donor.indexOf('Ж (')!= -1)
									thisGender[thisIndex] = 0;
							}

							if (donor.indexOf('М (')!= -1)
									curGender = 1;
							if (donor.indexOf('Ж (')!= -1)
									curGender = 0;

							if (curGender === thisGender[thisIndex])
							{

								var donor,startcut,newValue;
								var currentValue = $(this).find('progress').attr('value');
								var maxValue = Number($(this).find('progress').attr('max'));
								var currentProcent = Number(($(this).find('p.progvalue').text()).substring(0,($(this).find('p.progvalue').text()).indexOf('%')));

								donor = $(ui.draggable).text();
								startcut = donor.indexOf('(');
								endcut = donor.indexOf(')');
								addition =donor.substring(startcut+1,endcut);
								$("<span class='desc'>").appendTo(this).text(donor);
								newValue = Number(currentValue) +  Number(addition);
								$(this).find('progress').attr('value',newValue);
								

								if (newValue > maxValue)
								{
									$(this).find('p.progvalue').css('color','red');
									$(this).find('h2').css('color','red');
									$(this).css('border-style','solid');
								}
								else 
								{
									$(this).find('p.progvalue').css('color','black');
									$(this).find('h2').css('color','black');
									$(this).css('border-style','dashed');
								}

								$(this).find('p.progvalue').text(newValue);

								$(ui.draggable).hide('fade',200);
							}
						}
					});


				});
			});
		});
		
		/**/
		$('#umucheck').change(function (){
			if ($(this).prop('checked'))
				kurs = 1;
			else kurs = 0;
			$('#umuselect').load('./scripts/get_umu_contingent.php?kurs='+kurs,function (){
				$("div.umugroup").find('span').not('#amount').text(str);
				var url = './scripts/get_umu_contingent.php?flag=' + String(idstr);
				$('span#amount').load(url,function (){

					//подгрузка физкультурных групп
					$('div#fizgroups').load('./scripts/get_subgroups.php?name='+str+'&flag=0',function () {

						var optimal = $('.fizgroup:first').find('progress').attr('max');
						$('#orient').text(optimal);

						/*Изменение названия физкультурной группы*/
						$('.fizgroup').find('h2').click(function (){
							var newNameFG = prompt('Введите название физкультурной группы: ');
							if (newNameFG != '')
								$(this).text(newNameFG);
						});

						/*Сохранение ФГ*/
						$('.fizgroup').find('img.saveicon').click(function (){
							var deleteStatus = 0;
							var papka = $(this).parent();
							var n = $(this).parent().find('span.desc').length;
							if (n == 0)
								alert('Не добавлена ни одна подгруппа!');
							else 
							{
								var jsonString = '{';
								for (i=0;i<n;i++)
								{
									var cutName;		
									var go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' М (');
									if (!(go+1))
										go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' Ж (');;
									cutName = ($(this).parent().find('span.desc').eq(i).text()).substring(0,go);
									jsonString += '"name'+i+'":"'+cutName+'"';
									if ($(this).parent().find('span.desc').eq(i).index() != $(this).parent().find('span.desc').eq(n-1).index())
										jsonString += ',';

								}
								jsonString += '}';
								//alert(jsonString);
								var papaName = $(this).parent().find('h2').text();
								var contName = $('.umugroup').find('span').not('#amount').text();
								var commitAjax = $.ajax({
									type: "GET",
									url:'./scripts/commit_fizgroup.php?name='+papaName+'&pname='+contName,
									data:{js:jsonString},
									dataType:"html",
									success: function (data){
										alert(data);
										deleteStatus = 1;
									},
									error: function (data){
										if (data == '-1')
											alert('Failed to load data');
									},
									complete: function(){
										if(deleteStatus == 1)
											{
												papka.remove();
											}
									}
								});

							}
						});

						/*Режим редактирования физкультурной группы*/
							$('.fizgroup').find('img.editicon').click(function (){
							$(this).attr('src','./images/pen_edited.png').css('border-color','red');
							curIndex = $(this).index();
							var daddy = $(this).parent();
							//если кликнули первый раз или ещё не кликали
							if (toggleFlags[curIndex] == 0 || typeof(toggleFlags[curIndex])=='undefined')
							{
								
								handleClicker = function(dad,id) {
									var spanContent = $('span').eq(id).text();
									$(".subgroup:contains('"+spanContent+"')").show('fade',300);
									$('span').eq(id).remove();

									currentValue = dad.find('progress').attr('value');

									startcut = spanContent.indexOf('(');
									endcut = spanContent.indexOf(')');
									addition =spanContent.substring(startcut+1,endcut);
									newValue = Number(currentValue) -  Number(addition);
									dad.find('progress').attr('value',newValue);
									if (newValue > optimal)
									{
										dad.find('p.progvalue').css('color','red');
										dad.find('h2').css('color','red');
										dad.css('border-style','solid');
									}
									else 
									{
										dad.find('p.progvalue').css('color','black');
										dad.find('h2').css('color','black');
										dad.css('border-style','dashed');
									}

									dad.find('p.progvalue').text(newValue);
									dad.find('progress').attr('value',newValue);

									var thisIndex = dad.index();
									if (dad.find('span.desc').length == 0)
										drags[thisIndex] = 0;

								}

								daddy.find('span.desc').css({
									'text-decoration':'underline',
									'cursor':'pointer',
									'color':'#66ccff'});
								clickCounter = 1;
								//обработка события нажатия на редактируемую группу
								daddy.find('span.desc').click(function (){
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
								toggleFlags[curIndex] = 1;

							}
							//если уже включали режим редактирования
							else if (toggleFlags[curIndex] == 1)
							{
								clickCounter = 0;
								$(this).attr('src','./images/pen.png').css('border-color','black');
								daddy.find('span.desc').css({
									'text-decoration':'none',
									'cursor':'default',
									'color':'black'});
								daddy.find('span.desc').click(function (){
									spanID = $('span').index(this);
								});
								toggleFlags[curIndex] = 0;
							}
						});

						
						/*Удаление физкультурной группы*/
						$('.fizgroup').find('img.deleteicon').click(function (){
							if (confirm('Вы действительно хотите удалить ФГ "'+$(this).parent().find('h2').text()+'"'))
								{
									var parentDiv = $(this).parent();
									var restoreSubLen = parentDiv.find('span.desc').length;
									for (i=0;i<restoreSubLen;i++)
									{
										spanContent = parentDiv.find('span.desc').eq(i).text();
										//alert(spanContent);
										$(".subgroup:contains('"+spanContent+"')").show('fade',300);
										$('span').eq(i).hide('fade',300);
										$('span').eq(i).remove();
									}
									$(this).parent().hide('fade',300);
									$(this).parent().remove();
								}
						});

						$('.fizgroup').droppable({
							drop:function(event,ui){
								
								/*определяем пол*/
								thisIndex = $(this).index();
								var curGender;
								
								drags[thisIndex]++;
								donor = $(ui.draggable).text();
								var donor,startcut,newValue;
								
								if (drags[thisIndex] <= 1)
								{
									if (donor.indexOf('М (')!= -1)
										thisGender[thisIndex] = 1;
									if (donor.indexOf('Ж (')!= -1)
										thisGender[thisIndex] = 0;
								}

								if (donor.indexOf('М (')!= -1)
										curGender = 1;
								if (donor.indexOf('Ж (')!= -1)
										curGender = 0;

								if (curGender === thisGender[thisIndex])
								{

									var donor,startcut,newValue;
									var currentValue = $(this).find('progress').attr('value');
									var maxValue = Number($(this).find('progress').attr('max'));
									var currentProcent = Number(($(this).find('p.progvalue').text()).substring(0,($(this).find('p.progvalue').text()).indexOf('%')));

									donor = $(ui.draggable).text();
									startcut = donor.indexOf('(');
									endcut = donor.indexOf(')');
									addition =donor.substring(startcut+1,endcut);
									$("<span class='desc'>").appendTo(this).text(donor);
									newValue = Number(currentValue) +  Number(addition);
									$(this).find('progress').attr('value',newValue);
									

									if (newValue > maxValue)
									{
										$(this).find('p.progvalue').css('color','red');
										$(this).find('h2').css('color','red');
										$(this).css('border-style','solid');
									}
									else 
									{
										$(this).find('p.progvalue').css('color','black');
										$(this).find('h2').css('color','black');
										$(this).css('border-style','dashed');
									}

									$(this).find('p.progvalue').text(newValue);

									$(ui.draggable).hide('fade',200);
								}
							}
						});


					});
				});
				});

				//и два

				$('#umuselect').load('./scripts/get_umu_contingent.php?kurs='+kurs,function (){
				var str_pot = $('#umuselect').find('option:eq(0)').val();
				$('.umugroup').find('span').not('#amount').text(str_pot);
				str = $("#umuselect option:selected").text();
				idstr = $('#umuselect option:selected').index();
				$('div.list-items').load('./scripts/get_subgroups.php?name='+str+'&flag=1',function (){
					//подгрузка подгрупп
					$('.subgroup').draggable({ 
					revert: true,
					stack: ".subgroup",
					containment:"#wrapper",
					scroll:false
					});
					//подгрузка названия потока и количества часов
					$("div.umugroup").find('span').not('#amount').text(str);
					var url = './scripts/get_umu_contingent.php?kurs='+kurs;
					$('span#amount').load(url,function (){
						//подгрузка физкультурных групп
						$('div#fizgroups').load('./scripts/get_subgroups.php?name='+str+'&flag=0',function () {

							
							var cur_Gender;
							/*Инициализация количества перетаскиваний*/
							var kol_fizgr = $(this).find('.fizgroup').length;
							for (i=0;i<kol_fizgr;i++)
								drags[i] = 0;
							var optimal = $(this).find('progress').attr('max');
							$('#orient').text(optimal);

							/*Изменение названия физкультурной группы*/
							$('.fizgroup').find('h2').click(function (){
								var newNameFG = prompt('Введите название физкультурной группы: ');
								if (newNameFG != '')
									$(this).text(newNameFG);
							});

							/*Сохранение ФГ*/
							$('.fizgroup').find('img.saveicon').click(function (){
								var deleteStatus = 0;
								var papka = $(this).parent();
								var n = $(this).parent().find('span.desc').length;
								if (n == 0)
									alert('Не добавлена ни одна подгруппа!');
								else 
								{
									var jsonString = '{';
									for (i=0;i<n;i++)
									{
										var cutName;		
										var go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' М (');
										if (!(go+1))
											go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' Ж (');;
										cutName = ($(this).parent().find('span.desc').eq(i).text()).substring(0,go);
										jsonString += '"name'+i+'":"'+cutName+'"';
										if ($(this).parent().find('span.desc').eq(i).index() != $(this).parent().find('span.desc').eq(n-1).index())
											jsonString += ',';

									}
									jsonString += '}';
									//alert(jsonString);
									var papaName = $(this).parent().find('h2').text();
									var contName = $('.umugroup').find('span').not('#amount').text();
									var commitAjax = $.ajax({
										type: "GET",
										url:'./scripts/commit_fizgroup.php?name='+papaName+'&pname='+contName,
										data:{js:jsonString},
										dataType:"html",
										success: function (data){
											alert(data);
											deleteStatus = 1;
										},
										error: function (data){
											if (data == '-1')
												alert('Failed to load data');
										},
										complete: function(){
											if(deleteStatus == 1)
												{
													papka.remove();
												}
										}
									});

								}
							});

							/*Режим редактирования физкультурной группы*/
							$('.fizgroup').find('img.editicon').click(function (){
								$(this).attr('src','./images/pen_edited.png').css('border-color','red');
								curIndex = $(this).index();
								var daddy = $(this).parent();
								//если кликнули первый раз или ещё не кликали
								if (toggleFlags[curIndex] == 0 || typeof(toggleFlags[curIndex])=='undefined')
								{
									
									handleClicker = function(dad,id) {
										var spanContent = $('span').eq(id).text();
										$(".subgroup:contains('"+spanContent+"')").show('fade',300);
										$('span').eq(id).remove();

										currentValue = dad.find('progress').attr('value');

										startcut = spanContent.indexOf('(');
										endcut = spanContent.indexOf(')');
										addition =spanContent.substring(startcut+1,endcut);
										newValue = Number(currentValue) -  Number(addition);
										dad.find('progress').attr('value',newValue);
										if (newValue > optimal)
										{
											dad.find('p.progvalue').css('color','red');
											dad.find('h2').css('color','red');
											dad.css('border-style','solid');
										}
										else 
										{
											dad.find('p.progvalue').css('color','black');
											dad.find('h2').css('color','black');
											dad.css('border-style','dashed');
										}

										dad.find('p.progvalue').text(newValue);
										dad.find('progress').attr('value',newValue);
										var thisIndex = dad.index();
										if (dad.find('span.desc').length == 0)
											drags[thisIndex] = 0;

									}

									daddy.find('span.desc').css({
										'text-decoration':'underline',
										'cursor':'pointer',
										'color':'#66ccff'});
									clickCounter = 1;
									//обработка события нажатия на редактируемую группу
									daddy.find('span.desc').click(function (){
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
									toggleFlags[curIndex] = 1;

								}
								//если уже включали режим редактирования
								else if (toggleFlags[curIndex] == 1)
								{
									clickCounter = 0;
									$(this).attr('src','./images/pen.png').css('border-color','black');
									daddy.find('span.desc').css({
										'text-decoration':'none',
										'cursor':'default',
										'color':'black'});
									daddy.find('span.desc').click(function (){
										spanID = $('span').index(this);
									});
									toggleFlags[curIndex] = 0;
								}
							});

							/*Удаление физкультурной группы*/
							$('.fizgroup').find('img.deleteicon').click(function (){
								if (confirm('Вы действительно хотите удалить ФГ "'+$(this).parent().find('h2').text()+'"?'))
									{
										var parentDiv = $(this).parent();
										var restoreSubLen = parentDiv.find('span.desc').length;
										for (i=0;i<restoreSubLen;i++)
										{
											spanContent = parentDiv.find('span.desc').eq(i).text();
											//alert(spanContent);
											$(".subgroup:contains('"+spanContent+"')").show('fade',300);
											$('span').eq(i).hide('fade',300);
											$('span').eq(i).remove();
										}
										$(this).parent().hide('fade',300);
										$(this).parent().remove();
									}
							});

							/*Обработка события "перетащить подгруппу в физкультурную группу" */
							$('.fizgroup').droppable({
								drop:function(event,ui){
									
									/*определяем пол*/
									var thisIndex = $(this).index();
									var curGender;
									
									drags[thisIndex]++;
									donor = $(ui.draggable).text();
									var donor,startcut,newValue;
									
									if (drags[thisIndex] <= 1)
									{
										if (donor.indexOf('М (')!= -1)
											thisGender[thisIndex] = 1;
										if (donor.indexOf('Ж (')!= -1)
											thisGender[thisIndex] = 0;
									}

									if (donor.indexOf('М (')!= -1)
											curGender = 1;
									if (donor.indexOf('Ж (')!= -1)
											curGender = 0;

									if (curGender == thisGender[thisIndex])
									{
										var currentValue = $(this).find('progress').attr('value');
										var maxValue = Number($(this).find('progress').attr('max'));
										var currentProcent = Number(($(this).find('p.progvalue').text()).substring(0,($(this).find('p.progvalue').text()).indexOf('%')));

										startcut = donor.indexOf('(');
										endcut = donor.indexOf(')');
										addition =donor.substring(startcut+1,endcut);
										$("<span class='desc'>").appendTo(this).text(donor);
										newValue = Number(currentValue) +  Number(addition);
										$(this).find('progress').attr('value',newValue);
										
										if (newValue > maxValue)
										{
											$(this).find('p.progvalue').css('color','red');
											$(this).find('h2').css('color','red');
											$(this).css('border-style','solid');
										}
										else 
										{
											$(this).find('p.progvalue').css('color','black');
											$(this).find('h2').css('color','black');
											$(this).css('border-style','dashed');
										}

										$(this).find('p.progvalue').text(newValue);

										$(ui.draggable).hide('fade',200);
									}
								}
							});


						});
					});
				});
		
		/**/
		$('#umucheck').change(function (){
			if ($(this).prop('checked'))
				kurs = 1;
			else kurs = 0;
			$('#umuselect').load('./scripts/get_umu_contingent.php?kurs='+kurs);
		});


	});
				
		});
	});

	/*Заполняем select значениями из базы*/
	if ($('#umucheck').prop('checked'))
		var kurs = 1;
	else kurs = 0;
	$('#umuselect').load('./scripts/get_umu_contingent.php?kurs='+kurs,function (){
		var str_pot = $('#umuselect').find('option:eq(0)').val();
		$('.umugroup').find('span').not('#amount').text(str_pot);
		str = $("#umuselect option:selected").text();
		idstr = $('#umuselect option:selected').index();
		$('div.list-items').load('./scripts/get_subgroups.php?name='+str+'&flag=1',function (){
			//подгрузка подгрупп
			$('.subgroup').draggable({ 
			revert: true,
			stack: ".subgroup",
			containment:"#wrapper",
			scroll:false
			});
			//подгрузка названия потока и количества часов
			$("div.umugroup").find('span').not('#amount').text(str);
			var url = './scripts/get_umu_contingent.php?kurs='+kurs;
			$('span#amount').load(url,function (){
				//подгрузка физкультурных групп
				$('div#fizgroups').load('./scripts/get_subgroups.php?name='+str+'&flag=0',function () {

					
					var cur_Gender;
					/*Инициализация количества перетаскиваний*/
					var kol_fizgr = $(this).find('.fizgroup').length;
					for (i=0;i<kol_fizgr;i++)
						drags[i] = 0;
					var optimal = $(this).find('progress').attr('max');
					$('#orient').text(optimal);

					/*Изменение названия физкультурной группы*/
					$('.fizgroup').find('h2').click(function (){
						var newNameFG = prompt('Введите название физкультурной группы: ');
						if (newNameFG != '')
							$(this).text(newNameFG);
					});

					/*Сохранение ФГ*/
					$('.fizgroup').find('img.saveicon').click(function (){
						var n = $(this).parent().find('span.desc').length;
						var deleteStatus = 0;
						var papka = $(this).parent();
						if (n == 0)
							alert('Не добавлена ни одна подгруппа!');
						else 
						{
							var jsonString = '{';
							for (i=0;i<n;i++)
							{
								var cutName;		
								var go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' М (');
								if (!(go+1))
									go = ($(this).parent().find('span.desc').eq(i).text()).indexOf(' Ж (');;
								cutName = ($(this).parent().find('span.desc').eq(i).text()).substring(0,go);
								jsonString += '"name'+i+'":"'+cutName+'"';
								if ($(this).parent().find('span.desc').eq(i).index() != $(this).parent().find('span.desc').eq(n-1).index())
									jsonString += ',';

							}
							jsonString += '}';
							//alert(jsonString);
							var papaName = $(this).parent().find('h2').text();
							var contName = $('.umugroup').find('span').not('#amount').text();
							var commitAjax = $.ajax({
								type: "GET",
								url:'./scripts/commit_fizgroup.php?name='+papaName+'&pname='+contName,
								data:{js:jsonString},
								dataType:"html",
								success: function (data){
									alert(data);
									deleteStatus = 1;
								},
								error: function (data){
									if (data == '-1')
										alert('Failed to load data');
								},
								complete: function(){
									if(deleteStatus == 1)
										{
											papka.remove();
											if($('.fizgroup').length == 0)
											{
												var deact = $.ajax({
													type: "GET",
													url: './scripts/deactivate_cont.php?name='+contName,
													dataType: 'html',
													error: function(data) {
														alert(data);
													},
													complete: function() {
														$('#umuselect').load('./scripts/get_umu_contingent.php?kurs=0');
														$('#fizgroups').html("Добавлены все подгруппы из потока. Выберите новый поток.");
														//forceSelect();
													}
												});
											}
										}
								}
							});


						}
					});

					/*Режим редактирования физкультурной группы*/
					$('.fizgroup').find('img.editicon').click(function (){
						$(this).attr('src','./images/pen_edited.png').css('border-color','red');
						curIndex = $(this).index();
						var daddy = $(this).parent();
						//если кликнули первый раз или ещё не кликали
						if (toggleFlags[curIndex] == 0 || typeof(toggleFlags[curIndex])=='undefined')
						{
							
							handleClicker = function(dad,id) {
								var spanContent = $('span').eq(id).text();
								$(".subgroup:contains('"+spanContent+"')").show('fade',300);
								$('span').eq(id).remove();

								currentValue = dad.find('progress').attr('value');

								startcut = spanContent.indexOf('(');
								endcut = spanContent.indexOf(')');
								addition =spanContent.substring(startcut+1,endcut);
								newValue = Number(currentValue) -  Number(addition);
								dad.find('progress').attr('value',newValue);
								if (newValue > optimal)
								{
									dad.find('p.progvalue').css('color','red');
									dad.find('h2').css('color','red');
									dad.css('border-style','solid');
								}
								else 
								{
									dad.find('p.progvalue').css('color','black');
									dad.find('h2').css('color','black');
									dad.css('border-style','dashed');
								}

								dad.find('p.progvalue').text(newValue);
								dad.find('progress').attr('value',newValue);
								var thisIndex = dad.index();
								if (dad.find('span.desc').length == 0)
									drags[thisIndex] = 0;

							}

							daddy.find('span.desc').css({
								'text-decoration':'underline',
								'cursor':'pointer',
								'color':'#66ccff'});
							clickCounter = 1;
							//обработка события нажатия на редактируемую группу
							daddy.find('span.desc').click(function (){
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
							toggleFlags[curIndex] = 1;

						}
						//если уже включали режим редактирования
						else if (toggleFlags[curIndex] == 1)
						{
							clickCounter = 0;
							$(this).attr('src','./images/pen.png').css('border-color','black');
							daddy.find('span.desc').css({
								'text-decoration':'none',
								'cursor':'default',
								'color':'black'});
							daddy.find('span.desc').click(function (){
								spanID = $('span').index(this);
							});
							toggleFlags[curIndex] = 0;
						}
					});

					/*Удаление физкультурной группы*/
					$('.fizgroup').find('img.deleteicon').click(function (){
						if (confirm('Вы действительно хотите удалить ФГ "'+$(this).parent().find('h2').text()+'"?'))
							{
								var parentDiv = $(this).parent();
								var restoreSubLen = parentDiv.find('span.desc').length;
								for (i=0;i<restoreSubLen;i++)
								{
									spanContent = parentDiv.find('span.desc').eq(i).text();
									//alert(spanContent);
									$(".subgroup:contains('"+spanContent+"')").show('fade',300);
									$('span').eq(i).hide('fade',300);
									$('span').eq(i).remove();
								}
								$(this).parent().hide('fade',300);
								$(this).parent().remove();
							}
					});

					/*Обработка события "перетащить подгруппу в физкультурную группу" */
					$('.fizgroup').droppable({
						drop:function(event,ui){
							
							/*определяем пол*/
							var thisIndex = $(this).index();
							var curGender;
							
							drags[thisIndex]++;
							donor = $(ui.draggable).text();
							var donor,startcut,newValue;
							
							if (drags[thisIndex] <= 1)
							{
								if (donor.indexOf('М (')!= -1)
									thisGender[thisIndex] = 1;
								if (donor.indexOf('Ж (')!= -1)
									thisGender[thisIndex] = 0;
							}

							if (donor.indexOf('М (')!= -1)
									curGender = 1;
							if (donor.indexOf('Ж (')!= -1)
									curGender = 0;

							if (curGender == thisGender[thisIndex])
							{
								var currentValue = $(this).find('progress').attr('value');
								var maxValue = Number($(this).find('progress').attr('max'));
								var currentProcent = Number(($(this).find('p.progvalue').text()).substring(0,($(this).find('p.progvalue').text()).indexOf('%')));

								startcut = donor.indexOf('(');
								endcut = donor.indexOf(')');
								addition =donor.substring(startcut+1,endcut);
								$("<span class='desc'>").appendTo(this).text(donor);
								newValue = Number(currentValue) +  Number(addition);
								$(this).find('progress').attr('value',newValue);
								
								if (newValue > maxValue)
								{
									$(this).find('p.progvalue').css('color','red');
									$(this).find('h2').css('color','red');
									$(this).css('border-style','solid');
								}
								else 
								{
									$(this).find('p.progvalue').css('color','black');
									$(this).find('h2').css('color','black');
									$(this).css('border-style','dashed');
								}

								$(this).find('p.progvalue').text(newValue);

								$(ui.draggable).hide('fade',200);
							}
						}
					});


				});
			});
		});
		
		/**/
		$('#umucheck').change(function (){
			if ($(this).prop('checked'))
				kurs = 1;
			else kurs = 0;
			$('#umuselect').load('./scripts/get_umu_contingent.php?kurs='+kurs);
		});


	});


	/*Выводим текущий семестр*/
	$('span#cur_semestr').load('./scripts/get_semestr_string.php');


	/*Скрытие подсказки по клику в любом месте*/
	$('#wrapper').click(function (){
		$('#note').hide();		
	});

	/*Сделать все элементы подгрупп перетаскиваемыми*/
	$('.subgroup').draggable({ 
		revert: true,
		stack: ".subgroup",
		containment:"#wrapper",
		scroll:false
	});


	/*Вызов подсказки*/
	$('.question').click(function (){
		$('#note').show();
	});

	/*Изменение названия физкультурной группы*/
	$('.fizgroup').find('h2').click(function (){
		var newNameFG = prompt('Введите название физкультурной группы: ');
		if (newNameFG != '')
			$(this).text(newNameFG);
	});

				

});