const basePath = 'https://localhost:44372/';

export const getCurrentSeason = async () => {
    const result = await fetch(`${basePath}getCurrentSeason`);
    return await result.json();
}

export const getCurrentStandings = async (year) => {
    const result = await fetch(`${basePath}getCurrentStandings/${year}`);
    return await result.json();
}

export const getGroupStandings = async (year) => {
    const result = await fetch(`${basePath}getGroupStandings`);
    return await result.json();
}

export const getCurrentRoster = async (seasonTeamID) => {
    const result = await fetch(`${basePath}getRoster/${seasonTeamID}`);
    return await result.json();
}

export const getTeam = async (seasonTeamID) => {
    const result = await fetch(`${basePath}teams/${seasonTeamID}`);
    return await result.json();
}

export const getSeriesScheduleByEvent = async (eventID) => {
    const result = await fetch(`${basePath}getSeriesScheduleByEvent/${eventID}`);
    return await result.json();
}

export const getEvents = async () => {
    const result = await fetch(`${basePath}getEvents`);
    return await result.json();
}

export const getSeriesDetails = async (seriesID) => {
    const result = await fetch(`${basePath}getSeriesDetails/${seriesID}`);
    return await result.json();
}

