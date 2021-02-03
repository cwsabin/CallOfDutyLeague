import { getSeriesScheduleByEvent } from './api.js';

export function SeriesSchedule(props) {
    const [seriesList, setSeriesList] = React.useState([]);

    React.useEffect(() => {
        const getSchedule = async () => {
            setSeriesList(await getSeriesScheduleByEvent(props.eventID))
        }

        getSchedule()
    }, [props.eventID]);

    return (
        <ReactBootstrap.Container fluid>
            {seriesList.map((series) => (
                <ReactBootstrap.Row key={series.seriesID}>
                    <ReactBootstrap.Card>
                        <ReactBootstrap.Card.Header>{series.eventName}</ReactBootstrap.Card.Header>
                        <ReactBootstrap.Card.Body>
                            <ReactBootstrap.Card.Title>{<ReactBootstrap.Image style={{ width: '35px', height: '35px' }} src={series.awayTeamImageURL} />} {series.awayTeam} vs. {series.homeTeam} {<ReactBootstrap.Image style={{ width: '35px', height: '35px' }} src={series.homeTeamImageURL} responsive />}</ReactBootstrap.Card.Title>
                            <ReactBootstrap.Card.Text>
                                <ReactBootstrap.Row key="date">{series.seriesDate}</ReactBootstrap.Row>
                                <ReactBootstrap.Row key="gameNumber">Best of {series.bestOfGameNumber}</ReactBootstrap.Row>
                            </ReactBootstrap.Card.Text>
                        </ReactBootstrap.Card.Body>
                    </ReactBootstrap.Card>
                </ReactBootstrap.Row>
            ))}
        </ReactBootstrap.Container>
    );
}