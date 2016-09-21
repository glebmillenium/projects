
$m_coef = 2147483647
$a_coef = 630360016
p "Ввод n ="
n = gets.chomp.to_i
A = [rand($m_coef)]
t = 1
while(t<n) do
  A[t] = (($a_coef * A[t-1]) / $m_coef).to_i
  t = t + 1
end
i = (rand() * n).round
k = A[i]
t = 0
B = (A.inject(0){ |result, elem| result + elem })/($m_coef*n)
p B
