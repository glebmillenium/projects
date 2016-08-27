<?php
require_once('soap_fiz.php');
include('../include/header.inc.php');
$contingent = 965;
$test = $client->fiz_GetContingentCourse ($contingent);
print_r($test);
echo " blalbls";
?>