FIO = '�� �.�.'
number = 1321121
example = '������5'
print('��������: '..FIO..' ID = '..number..' Example = '..example)

x = 10
	local i = 1
	while i<= x do
		local x = i * 2 -- ��������� ���������� ������ ����� while
		print( x )
		i = i + 1
	end

	if i > 20 then
		local x
		x = 20
		print( x + 2 )
	else
		print( x )
	end

print(x)