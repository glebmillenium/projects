<?php
	include "Calculator.php";
	class CalculatorTest extends PHPUnit_Framework_TestCase
	{
            
	    public function testAdd()
	    {
                $obj = new Calculator();
		$this->assertEquals(2, $obj->Add(1, 1));
		$this->assertEquals(1, $obj->Subtraction(3, 2));
	    }
	    
            public function testSubtraction()
            {
                $obj = new Calculator();
                $this->assertEquals(2, $obj->Subtraction(3, 2));
            }
	}
?>
