const basePath = 'https://localhost:44372/';

export const getCurrentSeason = async () => {
    const result = await fetch(`${basePath}getCurrentSeason`);
    return await result.json();
}

export const getCurrentStandings = async (year) => {
    const result = await fetch(`${basePath}getCurrentStandings/${year}`);
    return await result.json();
}

