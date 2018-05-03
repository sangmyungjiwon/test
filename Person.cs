using System;

namespace VOC_LIST {
    class Person {
        string firstName;
        string secondName;
        string comments;
        public Person(string firstName, string secondName) {
            this.firstName = firstName;
            this.secondName = secondName;
            comments = String.Empty;
        }
        public Person(string firstName, string secondName, string comments)
            : this(firstName, secondName) {
            this.comments = comments;
        }
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        //테스트2
        public string SecondName {
            get { return secondName; }
            set { secondName = value; }
        }
        //테스트
        public string Comments {
            get { return comments; }
            set { comments = value; }
        }
    }
}