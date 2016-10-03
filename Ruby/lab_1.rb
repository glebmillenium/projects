$m_coef = 2147483647.0
$a_coef = 630360016.0
$n = 3000
$Xs = 0.0

p "Ввод n:"
mass = gets.chomp.to_i
A = [mass.to_i]
t = 1
while(t<$n) do
  A[t] = (($a_coef * A[t-1]) % $m_coef).to_i
  t = t + 1
end
i = (rand() * $n).round.to_i
p "Случайное значение =" + i.to_s
t = 0

while(t<$n) do
  $Xs = $Xs + (A[t]/$m_coef)/$n
  t = t + 1
end

p "Секретный ключ: "+ A[i].to_s
p "Среднее значение нормированного элемента: " + $Xs.to_s
