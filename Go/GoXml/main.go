package main

import (
	"fmt"
	"os"
	"encoding/xml"
	"io/ioutil"
	"regexp"
)

type StudentInp struct
{
	Name string `xml:"name,attr"`
	Mark string `xml:"mark,attr"`
}

type CourseInp struct
{
	Name string `xml:"name,attr"`
	Students []StudentInp `xml:"student"`
}

type Input struct
{
	Courses []CourseInp `xml:"course"`
}

type CourseOut struct
{
	Name string `xml:"name,attr"`
	Mark string `xml:"mark,attr"`
}

type StudentOut struct
{
	Name string `xml:"name,attr"`
	Courses []CourseOut `xml:"course"`
}

type Output struct
{
	XMLName  xml.Name `xml:"students"`
	Students []StudentOut `xml:"student"`
}

func main() {
	xmlFile, err := os.Open("input.xml")
	if (err != nil) {
		fmt.Println("Error opening file:", err)
		return
	}

	defer
		xmlFile.Close()
	var
	(
		inp Input
		out Output
	)

	inputFile, _ := ioutil.ReadAll(xmlFile)
	err = xml.Unmarshal(inputFile, &inp)
	if
	err != nil {
		fmt.Printf(
			"Error: %v\n", err)
		return
	}

	studKeys := make(map[string]int)
	for _, course := range inp.Courses {
		for _, student := range course.Students {
			if _, ok := studKeys[student.Name]; !ok {
				out.Students = append(out.Students, StudentOut{Name: student.Name})
				studKeys[student.Name] = len(out.Students) - 1
			}
			out.Students[studKeys[student.Name]].Courses =
				append(out.Students[studKeys[student.Name]].Courses,
					CourseOut{Name: course.Name, Mark: student.Mark})
		}
	}
	outputFile, err := xml.MarshalIndent(out, "  ", "    ")

	r := regexp.MustCompile("></[[:alnum:]]*>")
	outputString := r.ReplaceAllString(string(outputFile),"/>")
	outputFile = []byte(outputString)

	if err != nil {
		fmt.Printf("Error: %v	\n", err)
		return
	}

	err = ioutil.WriteFile("output.xml", outputFile,0644)
	if err != nil {
		fmt.Printf("E	rror: %v\n", err)
		return
	}
	fmt.Print("Successfull");
	return
}