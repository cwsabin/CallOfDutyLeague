import { getCurrentStandings, getGroupStandings } from './api.js';

export function TeamStandings(props) {
    const [teamList, setTeamList] = React.useState([]);
    const [groupedTeamList, setGroupedTeamList] = React.useState([]);

    React.useEffect(() => {
        const getStandings = async () => {
            setTeamList(await getCurrentStandings(props.season.year))            
        }

        const getCurrentGroupStandings = async () => {
            let data = await getGroupStandings();
            let groupedData = data.reduce(function (result, teamStanding) {
                result[teamStanding.stageGroupID] = result[teamStanding.stageGroupID] || [];
                result[teamStanding.stageGroupID].push(teamStanding);
                return result;
            }, Object.create(null));

            setGroupedTeamList(groupedData)
        }

        getStandings()
        getCurrentGroupStandings()        
    }, [props.season]);

    return (
        <ReactBootstrap.Container fluid>
            <ReactBootstrap.Row>
                <h3>Overall Standings</h3>
            </ReactBootstrap.Row>
            <ReactBootstrap.Row>
                <ReactBootstrap.Col key="overallStandings" md='auto'>
                    <ReactBootstrap.Table striped bordered hover variant="dark">
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
                    </ReactBootstrap.Table>
                </ReactBootstrap.Col>
            </ReactBootstrap.Row>
            <ReactBootstrap.Row>
                <h3>Current Group Standings</h3>
            </ReactBootstrap.Row>
            <ReactBootstrap.Row>
                {Object.keys(groupedTeamList).map((group) => (
                    <ReactBootstrap.Col key={group} md='auto'>
                        <ReactBootstrap.Table striped bordered hover variant="dark" key={group}>
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
                                {groupedTeamList[group].map((team) => (
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
                        </ReactBootstrap.Table>
                    </ReactBootstrap.Col>
                ))}
            </ReactBootstrap.Row>
        </ReactBootstrap.Container>
    );
}