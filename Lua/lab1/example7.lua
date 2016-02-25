FIO = 'Ан Г.В.'
number = 1321121
example = 'Пример07'
print('Выполнил: '..FIO..' ID = '..number..' Example = '..example)

	-- Функция определяет максимальный индекс в хэш
	function max_index(a)
		local mi = 1
		local m = a[mi]

		for i, val in ipairs(a) do
			if val > m then
				mi = i
				m = val
			end
		end
		
		return m, mi
	end

print(max_index({8, 10, 23, 12, 32, 5}))
