FIO = '�� �.�.'
number = 1321121
example = '������08'
print('��������: '..FIO..' ID = '..number..' Example = '..example)

	-- ������� ����� ������� �� �������� �����������
	function norm(x, y)
		local n2 = x^2 + y^2
		return math.sqrt(n2)
	end

	-- ����������� �������� �������� � 2 ����
	function twice(x)
		return 2 * x
	end

n = norm(3.4, 1.0)
print( twice(n) )