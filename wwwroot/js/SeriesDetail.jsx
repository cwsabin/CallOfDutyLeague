export function SeriesDetail(props) {
    let { seriesID } = window.ReactRouterDOM.useParams();
    const { series, getSeries } = React.useState(null);

    return (
        <label>TEST {seriesID}</label>
    );
}