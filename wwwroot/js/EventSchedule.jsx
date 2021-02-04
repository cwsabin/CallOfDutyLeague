import { getEvents } from './api.js';
import { SeriesSchedule } from './SeriesSchedule.jsx';

export function EventSchedule() {
    const [eventList, setEventList] = React.useState([]);
    const [eventID, setEventID] = React.useState(1);

    React.useEffect(() => {
        const getList = async () => {
            setEventList(await getEvents())
        }

        getList()
    }, []);

    return (
        <ReactBootstrap.Tabs defaultActiveKey="1">
            {eventList.map((event) => (
                <ReactBootstrap.Tab id={event.eventID} eventKey={event.eventID} title={event.eventName}>
                    <SeriesSchedule eventID={event.eventID}/>
                </ReactBootstrap.Tab>
            ))}
        </ReactBootstrap.Tabs>
    );
}