<?php

/**
 * WriteConstInPHPFiles
 *
 * PHP version 5
 *
 * @category  PHP
 * @package   PHP_CodeSniffer
 * @author    Gleb An <gleb@logics.net.au>
 * @copyright 2006 Squiz Pty Ltd (ABN 77 084 670 600)
 * @license   http://www.gefest.com.au/license Gefest proprietary license
 * @link    http://svn.logics.net.au/foundation/XML
 */

class WriteConstInPHPFiles
    {

	/**
	 * Folder path contains check files
	 *
	 * @var string
	 */
	private $_directory;

	/**
	 * Token code (type integer or string)
	 *
	 * @var string
	 */
	private $_token_code;

	/**
	 * Search string for record in config file
	 *
	 * @var string search string for record in config file
	 */
	private $_pattern;

	/**
	 * Folder path where create config file
	 *
	 * @var string
	 */
	private $_config_file;


	/**
	 * Construct for defined values from outer method
	 *
	 * @untranslatable /(@requiredconst|@optionalconst) ([A-Z_]+) '(.*)' (.+)/
	 *
	 * @return void
	 */

	function __construct($directory = "", $token_code = T_DOC_COMMENT, $pattern = "/(@requiredconst|@optionalconst) ([A-Z_]+) '(.*)' (.+)/",
	$directory_config_file = "config.php")
	    {
		$this->_directory   = $directory;
		$this->_token_code  = $token_code;
		$this->_pattern     = $pattern;
		$this->_config_file = fopen($directory_config_file, "w+");
	    } //end __construct()


	/**
	 * Main method that call other methods
	 *
	 * @return void
	 */

	public function createConfigConst()
	    {
		fwrite($this->_config_file, "<?php\r\n");
		$array_of_file_names = array();
		$array_of_file_names = $this->_getArrayFiles($this->_directory);
		$this->_processingScriptFiles($array_of_file_names);
		fwrite($this->_config_file, "?>\r\n");
		fclose($this->_config_file);
	    } //end createConfigConst()


	/**
	 * Recoursivly reads files and
	 * write path every file in array
	 *
	 * @param string $path_dir
	 *
	 * @return array
	 */

	function _getArrayFiles($path_dir)
	    {
		$array_path = array();
		$dir = new RecursiveDirectoryIterator($path_dir);
		foreach (new RecursiveIteratorIterator($dir) as $val)
		    {
			if ($val->isFile() === true)
			    {
				$array_path[] = $val->getPathname();
			    }
		    }
		return $array_path;
	    } //end _getArrayFiles()


	/**
	 * Treatment Files
	 *
	 * @param array $array_of_file_names array contains the path to the files
	 *
	 * @return void
	 */

	function _processingScriptFiles($array_of_file_names)
	    {
		$content_file = array();
		foreach ($array_of_file_names as $directory_file)
		    {
			$this->_searchTokenCommentContentConstant(token_get_all(file_get_contents($directory_file)));
		    }
	    } //end _processingScriptFiles()


	/**
	 * Search token which matches
	 * needs token for generating config file
	 *
	 * @param array $arrayWithTokens tokens from single file
	 *
	 * @return void
	 */

	function _searchTokenCommentContentConstant($arrayWithTokens)
	    {
		foreach ($arrayWithTokens as $key => $token)
		    {
			if ($token[0] === $this->_token_code)
			    {
				preg_match_all($this->_pattern, $token[1], $matches);
				$this->_writeToConfig($matches);
			    }
		    }
	    } //end _searchTokenCommentContentConstant()


	/**
	 * 
	 *
	 */
	function _writeToConfig($matches)
	    {
		for ($i = 0; $i < count($matches[1] ); ++$i)
		    {
			if ($matches[1][$i] === "@optionalconst")
			    {
				$type_const = "//";
			    }
			else
			    {
				$type_const = "";
			    }
			fwrite($this->_config_file, "//".$matches[4][$i]."\r\n".$type_const."define('".$matches[2][$i].", "."'".$matches[3][$i]."');"."\r\n\r\n");
		    }
	    } //end _writeToConfig()


    } //end class

?>
