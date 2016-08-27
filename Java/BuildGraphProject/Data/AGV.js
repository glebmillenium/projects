function evaluationExpression_fx(str, x) {
    var y;
    y=eval(treatmenter(str));
    return y * 1.0;
}


function evaluationExpression_ft(str, t) {
    var y;
    y=eval(treatmenter(str));
    return y * 1.0;
}

function evaluationExpression_polar(str, a) {
    var y;
    y=eval(treatmenter(str));
    return y * 1.0;
}

function treatmenter(str)
{
	str = str.replace(/floor/g, " M a t h . f l o o r ");
	str = str.replace(/arccos/g, " M a t h . a c o s ");
	str = str.replace(/_gr/g, "*Math.PI/180");
	str = str.replace(/random/g, "Math.rand om");
	str = str.replace(/arcsin/g, "Math.as in");
	str = str.replace(/sin/g, "Math.s in");
	str = str.replace(/arctg/g, "Math.a tan");
	str = str.replace(/arctg/g, "Math.ata n");
	str = str.replace(/exp/g, "Math.e x p");
	str = str.replace(/sqrt/g, "Math.sq rt");
	str = str.replace(/ln/g, "Math.lo g");
	str = str.replace(/cos/g, "Math.co s");
	str = str.replace(/csc/g, "1/Math.co s");
	str = str.replace(/sc/g, "1/Math.s in");
	str = str.replace(/ctg/g, "1/Math.ta n");
	str = str.replace(/tg/g, "Math.ta n");
	str = str.replace(/pow/g, "Math.po w");
	str = str.replace(/abs/g, "Math.ab s");
	str = str.replace(/round/g, "Math.r ound");

	str = str.replace(/ /g, "");
	return str;
}

function sqr(x)
{
	return x*x;
}

function sign(x)
{
	var res;
	if (x<0) res =-1.0;
	if (x>0) res =1.0;
	if (x==0) res =0.0;
	return res;
}

function Hvs(x)
{
	var res;
	if (x<0) res =0.0;
	if (x>0) res =1.0;
	if (x==0) res =0.0;
	return res;
}
