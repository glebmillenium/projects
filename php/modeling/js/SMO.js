
	
	function getXMLHttpRequest()	{
		var xmlhttp;
		try{
			xmlhttp=new ActiveXObject("Msxml2.XMLHTTP");
		}catch(E){
			xmlhttp=false;
		}
		
		if(!xmlhttp && typeof(XMLHttpRequest) != 'undefined'){
			xmlhttp=new XMLHttpRequest();
		}
		return xmlhttp;
	}
	
	function getCountSMO(chanels,lambda,t_obs,n,trunc){
		var req = getXMLHttpRequest();
		req.onreadystatechange = function(){
			if(req.readyState != 4) return;
			
			var result = document.getElementById('divResult');
			var str=req.responseText;
			result.firstChild.nodeValue = str;
		}
		req.open(	'GET',
					'./scripts/smo_data_output.php?chanels='+chanels+"&lambda="+lambda+"&t_obs="+t_obs+"&n="+n+"&truncate="+trunc,
					true);
		req.send(null);
	}
	
	function showSMO(){
		var chanels=document.getElementById('chanels');
		var lambda = document.getElementById('lambda');
		var t_obs = document.getElementById('t_obs');
		var n = document.getElementById('n');
		var trunc = document.getElementById('truncate');
		
		getCountSMO(chanels.value,lambda.value,t_obs.value,n.value,trunc.value);
	}