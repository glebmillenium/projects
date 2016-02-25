FIO = 'Ан Г.В.'
number = 1321121
example = 'Пример08'
print('Выполнил: '..FIO..' ID = '..number..' Example = '..example)

	-- Находит длину вектора по заданным координатам
	function norm(x, y)
		local n2 = x^2 + y^2
		return math.sqrt(n2)
	end

	-- Увеличивает заданную величину в 2 раза
	function twice(x)
		return 2 * x
	end

n = norm(3.4, 1.0)
print( twice(n) )