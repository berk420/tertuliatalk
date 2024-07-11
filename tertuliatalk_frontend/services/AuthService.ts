import { createGlobalStyle } from 'styled-components';
import { EnvVars } from '../env';

//this function is a simple example, later we create middleware for authentications 
const signUp = async (email: string, password: string) => {
  try {
    const response = await fetch(`${EnvVars.API_URL}/api/auth/signup`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email: email,
        password: password,
      }),
    });
    console.log(await response.json());

    return await response.json();
  } catch (error) {
    console.log(error);
  }
};

export { signUp };
