import { EnvVars } from 'env';
import { Course, CreateCourse } from 'types/Course';

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
};

export const getCourses = async (startDate: string, endDate: string): Promise<Course[]> => {
  const response = await fetch(
    `${EnvVars.API_URL}/get-by-date-range?startDate=${startDate}&endDate=${endDate}`,
    {
      method: 'GET',
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json',
      },
    },
  );
  console.log('Courses response:', response);
  if (!response.ok) {
    throw new Error('Veri çekme hatası');
  }
  return response.json();
};

export { addCourse };
