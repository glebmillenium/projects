FIO = '�� �.�.'
number = 1321121
example = '������06'
print('��������: '..FIO..' ID = '..number..' Example = '..example)

	-- ��������� ����������� �������
	function fact(n)
		if n == 0 then
			return 1
		else
			return n * fact(n - 1)
		end
	end

-- print("enter a number: ")
-- a = io.read()     --read a number

a = 4
print( fact(a) )