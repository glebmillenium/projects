<?php
    require_once "WriteConstInPHPFiles.php";
    $dir = "baselib";
    (new WriteConstInPHPFiles($dir))->createConfigConst();
?>