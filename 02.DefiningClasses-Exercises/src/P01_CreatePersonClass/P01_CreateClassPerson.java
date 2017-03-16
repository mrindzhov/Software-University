package P01_CreatePersonClass;

import java.lang.reflect.Field;

public class P01_CreateClassPerson {

    public static void main(String[] args) throws Exception {
        Class person = Person.class;
        Field[] fields = person.getDeclaredFields();
        System.out.println(fields.length);
    }

}

