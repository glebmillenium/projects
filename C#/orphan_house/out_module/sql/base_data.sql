INSERT INTO
	`auth` (`login`, `password`, `id`)
VALUES
	('admin', '1111', 1);
	
INSERT INTO
	`adult` (`id`, `id_passport`, `full_name`, `place_work`, `position_work`, `adress`, `id_status`)
VALUES
	(1, 1, 'Administrator Information System', 'Сирот. дом', 'Администратор системы', 'Булгакова 12, кв. 75', 6);

INSERT INTO
	`passport` (`id_passport`, `p_series`, `p_number`, `who`, `date_reg`, `code`)
VALUES
	(1, 2531, 645282, 'отд. УФМС, г.Усть-Илимск', '2015-12-02', '093');

INSERT INTO
	`status` (`id`, `description`)
VALUES
	(0, 'Ребенок из приюта'),
	(1, 'Ребенок, который был в приюте'),
	(2, 'Родитель биологический'),
	(3, 'Родитель приемный'),
	(4, 'Работник приюта'),
	(5, 'Биологический родитель, который стал приемным'),
	(6, 'Администратор');
	
INSERT INTO
	`childrens` (`id`, `full_name`, `birthday`)
VALUES
	(0, 'Иванов Иван Иваныч', '1995-02-21')