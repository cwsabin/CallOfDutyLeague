import { getCurrentStandings } from './api.js';

export function TeamStandings(props) {
    const [teamList, setTeamList] = React.useState([]);

    React.useEffect(() => {
        const getStandings = async () => {
            setTeamList(await getCurrentStandings(props.season.year))            
        }

        getStandings()
    }, [props.season]);

    return (
        <div>Standings
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Wins</th>
                            <th>Losses</th>
                            <th>Map Wins</th>
                            <th>Map Losses</th>
                        </tr>
                    </thead>
                    <tbody>
                        {teamList.map((team) => (
                            <tr key={team.seasonTeamID}>
                                <td>
                                    <window.ReactRouterDOM.Link to={`/teams/${team.seasonTeamID}`}>{team.teamName}</window.ReactRouterDOM.Link>
                                </td>
                                <td>{team.wins}</td>
                                <td>{team.losses}</td>
                                <td>{team.mapWins}</td>
                                <td>{team.mapLosses}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}