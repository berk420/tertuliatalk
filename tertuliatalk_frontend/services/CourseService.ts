import { EnvVars } from "env";
import { CreateCourse } from "types/Course";

const addCourse = async (course: CreateCourse) => {
    try {
        const response = await fetch(`${EnvVars.API_URL}/api/Course/course-add`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                request: course,
            }),
        });
        console.log('Course add response:', response);
        if (!response.ok) {
            const contentType = response.headers.get('content-type');
            if (contentType && contentType.indexOf('application/json') !== -1) {
                const errorData = await response.json();
                throw new Error(JSON.stringify(errorData));
            } else {
                const errorText = await response.text();
                throw new Error(errorText);
            }
        }
    } catch (error) {
       console.log('Course add error:', error); 
    }
}

export { addCourse };