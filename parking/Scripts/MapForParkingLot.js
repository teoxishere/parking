var map;


function initMap() {
    var myLatlng = { lat: 44, lng: 22 };
    map = new google.maps.Map(document.getElementById('smallmap'), {
        zoom: 8,
        center: myLatlng,
        styles: [{ "featureType": "all", "elementType": "labels", "stylers": [{ "visibility": "on" }] }, { "featureType": "all", "elementType": "labels.text.fill", "stylers": [{ "saturation": 36 }, { "color": "#000000" }, { "lightness": 40 }] }, { "featureType": "all", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "on" }, { "color": "#000000" }, { "lightness": 16 }] }, { "featureType": "all", "elementType": "labels.icon", "stylers": [{ "visibility": "off" }] }, { "featureType": "administrative", "elementType": "geometry.fill", "stylers": [{ "color": "#000000" }, { "lightness": 20 }] }, { "featureType": "administrative", "elementType": "geometry.stroke", "stylers": [{ "color": "#000000" }, { "lightness": 17 }, { "weight": 1.2 }] }, { "featureType": "administrative.locality", "elementType": "labels.text.fill", "stylers": [{ "color": "#c4c4c4" }] }, { "featureType": "administrative.neighborhood", "elementType": "labels.text.fill", "stylers": [{ "color": "#707070" }] }, { "featureType": "landscape", "elementType": "geometry", "stylers": [{ "color": "#000000" }, { "lightness": 20 }] }, { "featureType": "poi", "elementType": "geometry", "stylers": [{ "color": "#000000" }, { "lightness": 21 }, { "visibility": "on" }] }, { "featureType": "poi.business", "elementType": "geometry", "stylers": [{ "visibility": "on" }] }, { "featureType": "poi.government", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#ff0000" }] }, { "featureType": "poi.park", "elementType": "geometry.fill", "stylers": [{ "visibility": "off" }, { "color": "#ff0000" }] }, { "featureType": "poi.place_of_worship", "elementType": "geometry.fill", "stylers": [{ "visibility": "off" }] }, { "featureType": "road.highway", "elementType": "geometry.fill", "stylers": [{ "color": "#e31921" }, { "lightness": "0" }, { "visibility": "on" }] }, { "featureType": "road.highway", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off" }] }, { "featureType": "road.highway", "elementType": "labels.text.fill", "stylers": [{ "visibility": "off" }] }, { "featureType": "road.highway", "elementType": "labels.text.stroke", "stylers": [{ "visibility": "off" }, { "hue": "#ff000a" }] }, { "featureType": "road.arterial", "elementType": "geometry", "stylers": [{ "color": "#000000" }, { "lightness": 18 }] }, { "featureType": "road.arterial", "elementType": "geometry.fill", "stylers": [{ "color": "#575757" }] }, { "featureType": "road.arterial", "elementType": "labels.text.fill", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "road.arterial", "elementType": "labels.text.stroke", "stylers": [{ "color": "#2c2c2c" }] }, { "featureType": "road.local", "elementType": "geometry", "stylers": [{ "color": "#000000" }, { "lightness": 16 }] }, { "featureType": "road.local", "elementType": "geometry.fill", "stylers": [{ "color": "#8e0b0b" }, { "visibility": "on" }] }, { "featureType": "road.local", "elementType": "labels.text.fill", "stylers": [{ "color": "#999999" }] }, { "featureType": "road.local", "elementType": "labels.text.stroke", "stylers": [{ "saturation": "-52" }] }, { "featureType": "transit", "elementType": "geometry", "stylers": [{ "color": "#000000" }, { "lightness": 19 }] }, { "featureType": "water", "elementType": "geometry", "stylers": [{ "color": "#000000" }, { "lightness": 17 }] }, { "featureType": "water", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#ffffff" }] }]
    });
    
    var marker = null;

    // This event listener calls addMarker() when the map is clicked.
    google.maps.event.addListener(map, 'click', function(e) {
        placeMarker(e.latLng, map);
    });

    function placeMarker(position, map) {
        if (marker != null) {
            marker.setMap(null);
            marker = null;
        }
        marker = new google.maps.Marker({
            position: position,
            map: map
        });  
        map.panTo(position);

        // Also update text boxes
        $("#Lng").val(position.lng());
        $("#Lat").val(position.lat());
    }

}