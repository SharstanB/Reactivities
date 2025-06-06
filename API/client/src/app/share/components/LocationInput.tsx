
type Props<T extends FieldValues> = {
    control: Control<T>;
    name: Path<T>;
  } & Omit<DateTimePickerProps, 'name'>
export default function LocationInput() {
  return (
    <div>LocationInput</div>
  )
}
