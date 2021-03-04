<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <!-- <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#modelId">
        Modal Test
      </button>
      <QuickModal /> -->
      <div class="masonry mt-2">
        <keeps-component v-for="r in state.keeps" :key="r.id" :keep-prop="r">
        </keeps-component>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, computed, onMounted } from 'vue'
// import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'HomePage',
  setup() {
    // const route = useRoute(),
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => {
      keepsService.getKeeps()
    })
    return {
      state
    }
  }
}
</script>

<style scoped lang="scss">

.home{
  text-align: center;
  user-select: none;
  // > img{
  //   height: 200px;
  //   width: 200px;
  // }
}

.masonry { /* Masonry container */
  column-count: 4;
  column-gap: 1em;
}

.item { /* Masonry bricks or child elements */
  background-color: #eee;
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;
}
</style>
