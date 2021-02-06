import { getSeriesDetails } from './api.js';

export function SeriesDetail(props) {
    let { seriesID } = window.ReactRouterDOM.useParams();
    const [seriesDetails, setSeriesDetails] = React.useState({ seriesMaps: []});

    React.useEffect(() => {
        const getSeriesDetailInfo = async () => {
            setSeriesDetails(await getSeriesDetails(seriesID))
        }

        getSeriesDetailInfo()
    }, []);

    return (
        <ReactBootstrap.Container fluid>
            <ReactBootstrap.Row>
                <h3>{seriesDetails.awayTeamName} vs {seriesDetails.homeTeamName}</h3>
            </ReactBootstrap.Row>
            <ReactBootstrap.Row>
                <ReactBootstrap.Tabs defaultActiveKey="1">
                    {seriesDetails.seriesMaps.map((seriesMap) => (
                        <ReactBootstrap.Tab id={seriesMap.seriesMapID} eventKey={seriesMap.seriesMapID} title={`${seriesDetails.awayTeamName} ${seriesMap.awayTeamScore} : ${seriesMap.homeTeamScore} ${seriesDetails.homeTeamName}`}>
                        </ReactBootstrap.Tab>
                    ))}
                </ReactBootstrap.Tabs>
            </ReactBootstrap.Row>
        </ReactBootstrap.Container>
    );
}