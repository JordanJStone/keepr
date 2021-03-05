<template>
  <div class="myKeepsComponent card mb-2">
    <img :src="keepProp.img" class="img-fluid">
    <h4 class="textPosition text-white">
      {{ keepProp.name }}
      <i class="fa fa-user ml-5" aria-hidden="true"></i>
    </h4>
  </div>
</template>

<script>
import { reactive } from 'vue'
// import { AppState } from '../AppState'
export default {
  name: 'MyKeepsComponent',
  props: {
    keepProp: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style scoped>
/* .imageFit{
  height: 100%;
  width: 100%;
  object-fit: contain;
  } */

  .myKeepsComponent {
  position: relative;
}

.textPosition {
  position: absolute;
  bottom: 0px;
  left: 4px;
  font-size: 18px;
}

</style>
