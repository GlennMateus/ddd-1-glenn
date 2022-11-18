export default interface PostalCode {
  id: number;
  postalCode: string;
  latitude: number;
  longitude: number;
  distanceInKM: number;
  distanceInMiles: number;
}

export const PostalCodeTableColumns = [
  {name: 'postalCode', label: 'Postal Code'},
  {name: 'distanceInKM', label: 'Distance in KM'},
  {name: 'distanceInMiles', label: 'Distance in Miles'}
]
