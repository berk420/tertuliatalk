import { EnvVars } from '../env';

export type WeatherForecast = {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
};

const getWeatherForecast = async (): Promise<WeatherForecast[]> => {
  try {
    const response = await fetch(`${EnvVars.API_URL}/WeatherForecast`, {
      method: 'GET',
      headers: {
        'Accept': 'text/plain',
      },
    });

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    return await response.json();
  } catch (error) {
    console.error('Fetching weather forecast failed:', error);
    return [];
  }
};

export { getWeatherForecast };
