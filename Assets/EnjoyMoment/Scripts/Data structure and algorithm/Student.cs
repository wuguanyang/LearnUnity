using System;
namespace DataStructureAndAlgorithm {
    public class Student : IComparable<Student> {
        int id;
        string name;
        public Student (int id) {
            this.id = id;
        }
        public Student (int id, string name) {
            this.id = id;
            this.name = name;
        }

        public int CompareTo (Student obj) {
            return this.id - obj.id;
        }

        public override bool Equals (object obj) {
            if (obj == null || !(obj is Student)) {
                return false;
            }
            if (this == obj) return true;
            return this.id.Equals (((Student) obj).id);
        }

        public override int GetHashCode () {
            return this.id.GetHashCode ();
        }

        public override string ToString () {
            return $"学生名字：{name}，ID：{id}";
        }
    }
}